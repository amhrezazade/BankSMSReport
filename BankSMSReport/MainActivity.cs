using AndroidX.RecyclerView.Widget;

namespace BankSMSReport
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private RecyclerView mRecyclerView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            ContentItem[] items =
                [
                new ContentItem()
                {
                    Title = "t1",
                    Text = "سلام سلام",
                    Date = "123"
                },
                new ContentItem()
                {
                    Title = "t2",
                    Text = "سلام ",
                    Date = "123"

                }
                ];
            SetRecyclerView(items);

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