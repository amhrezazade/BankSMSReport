using Android.Views;
using AndroidX.RecyclerView.Widget;

namespace BankSMSReport
{
    public class ContentItemViewHolder : RecyclerView.ViewHolder 
    {
        public View Item { get; }
        public TextView TitleTextView { get; }
        public TextView CaptionTextView { get; }
        public TextView TagTextView { get; }
        public Button BtLink { get; }
        public ImageView IvImage { get; }

        public ContentItemViewHolder(View itemView) : base(itemView)
        {
            Item = itemView.FindViewById(Resource.Id.content_item_view);
            BtLink = (Button)itemView.FindViewById(Resource.Id.btnFileContent);
            TitleTextView = (TextView)itemView.FindViewById(Resource.Id.tvTitleContent);
            IvImage = (ImageView)itemView.FindViewById(Resource.Id.ivImageShareContent);
            CaptionTextView = (TextView)itemView.FindViewById(Resource.Id.tvText);
            TagTextView = (TextView)itemView.FindViewById(Resource.Id.tvTag);
        }


        public void SetValues(ContentItem item)
        {
            TitleTextView.Text = item.Title;
            CaptionTextView.Text = item.Text;
            TagTextView.Text = item.Date;
        }

    }


}
