using Android.Views;
using AndroidX.RecyclerView.Widget;

namespace BankSMSReport.ContentItemList
{

    public class ContentItemAdapter(ContentItem[] Items, int Resource) : RecyclerView.Adapter
    {
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType) =>
            new ContentItemViewHolder(LayoutInflater.From(parent.Context).Inflate(Resource, parent, false));

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
            => (viewHolder as ContentItemViewHolder).SetValues(Items[position]);

        public override int ItemCount => Items.Length;

    }
}
