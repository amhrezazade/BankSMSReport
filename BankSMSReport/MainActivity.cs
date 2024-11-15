using Android;
using AndroidX.RecyclerView.Widget;
using BankSMSReport.ContentItemList;
using BankSMSReport.Model;

namespace BankSMSReport
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private RecyclerView mRecyclerView;
        private Button updateButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            updateButton = FindViewById<Button>(Resource.Id.btn_sms_update);
            updateButton.Click += btnUpdateClick;
            RequestPermissions([Manifest.Permission.ReadSms], 0);
        }

        private void btnUpdateClick(object sender, EventArgs e)
        {
            var items = GetAllSMS();
            var test = items.Select(x => new ContentItem()
            {
                Title = x.PhoneId,
                Text = x.Body,
                Date = x.Date,
                Id = x.PhoneId,
            }).ToArray();
            SetRecyclerView(test);
        }


        private BankSMS[] GetAllSMS(int take = 9999999)
        {
            string INBOX = "content://sms/inbox";
            string[] reqCols = ["_id", "thread_id", "address", "person", "date", "body", "type"];
            Android.Net.Uri uri = Android.Net.Uri.Parse(INBOX);
            var cursor = ContentResolver.Query(uri, reqCols, null, null, null);
            List<BankSMS> list = new();
            if (cursor.MoveToFirst())
            {
                do
                
                {
                    BankSMS sms = new();
                    sms.PhoneId = cursor.GetString(cursor.GetColumnIndex(reqCols[0]));
                    sms.ThreadId = cursor.GetString(cursor.GetColumnIndex(reqCols[1]));
                    sms.Address = cursor.GetString(cursor.GetColumnIndex(reqCols[2]));
                    sms.Person = cursor.GetString(cursor.GetColumnIndex(reqCols[3]));
                    sms.Date = cursor.GetString(cursor.GetColumnIndex(reqCols[4]));
                    sms.Body = cursor.GetString(cursor.GetColumnIndex(reqCols[5]));
                    sms.Type = cursor.GetString(cursor.GetColumnIndex(reqCols[6]));

                    if (sms.Body.Contains("بانک سامان"))
                        sms.BankType = "SAMAN";
                    else if (sms.Body.Contains("bki.ir"))
                        sms.BankType = "KESHAVARZI";
                    else if (sms.Body.Contains("بانک رفاه"))
                        sms.BankType = "REFAH";
                    else
                        continue;


                    list.Add(sms);
                    if (list.Count > take)
                        break;
                } while (cursor.MoveToNext());

            }
            return list.ToArray();
        }


        private void SetRecyclerView(ContentItem[] items)
        {
            int recyclerView = Resource.Id.main_layout_recyclerView;
            int cardView = Resource.Layout.card_view;
            mRecyclerView = FindViewById<RecyclerView>(recyclerView);
            mRecyclerView.SetLayoutManager(new LinearLayoutManager(this));
            mRecyclerView.SetAdapter(new ContentItemAdapter(items, cardView));
        }
    }
}