using Android.Views;
using AndroidX.RecyclerView.Widget;

namespace BankSMSReport.ContentItemList
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
            Item = itemView.FindViewById(_Microsoft.Android.Resource.Designer.ResourceConstant.Id.content_item_view);
            BtLink = (Button)itemView.FindViewById(_Microsoft.Android.Resource.Designer.ResourceConstant.Id.btnFileContent);
            TitleTextView = (TextView)itemView.FindViewById(_Microsoft.Android.Resource.Designer.ResourceConstant.Id.tvTitleContent);
            IvImage = (ImageView)itemView.FindViewById(_Microsoft.Android.Resource.Designer.ResourceConstant.Id.ivImageShareContent);
            CaptionTextView = (TextView)itemView.FindViewById(_Microsoft.Android.Resource.Designer.ResourceConstant.Id.tvText);
            TagTextView = (TextView)itemView.FindViewById(_Microsoft.Android.Resource.Designer.ResourceConstant.Id.tvTag);
        }


        public void SetValues(ContentItem item)
        {
            TitleTextView.Text = item.Title;
            CaptionTextView.Text = item.Text;
            TagTextView.Text = item.Date;
        }

    }


}
