using Android.Views;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSMSReport
{
    public class ContentItemViewHolder : RecyclerView.ViewHolder 
    {
        public View Item { get; }
        public TextView tvTitel { get; }
        public Button btLink { get; }
        public ImageView ivImage { get; }

        public ContentItemViewHolder(View itemView) : base(itemView)
        {
            Item = itemView.FindViewById(Resource.Id.ContentItemView);
            btLink = (Button)itemView.FindViewById(Resource.Id.btnFileContent);
            tvTitel = (TextView)itemView.FindViewById(Resource.Id.tvTitleContent);
            ivImage = (ImageView)itemView.FindViewById(Resource.Id.ivImageContent);
        }
    }

    public class ContentItemAdapter : RecyclerView.Adapter
    {
        ContentItem[] Items;
        Android.Content.Context co;
        public ContentItemAdapter(ContentItem[] List, Android.Content.Context ac = null)
        {
            if (ac == null)
                co = Application.Context;
            else
                co = ac;


            Items = List;
        }


        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType) =>
            new ContentItemViewHolder(LayoutInflater.From(parent.Context).Inflate(Resource.Layout.itemContent, parent, false));



        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            ContentItemViewHolder vh = viewHolder as ContentItemViewHolder;
            ContentItem item = Items[position];

/*
            vh.tvTitel.Text = item.Titel;
            vh.tvCaption.Text = item.Caption;
            vh.tvDate.Text = item.date;
            vh.tvN1.Text = item.GreenNote;
            vh.tvN2.Text = item.RedNote;
            vh.tvdef.Text = item.Def;

            vh.ivShareImage.Click += async (s, e) =>
            {
                await Share.RequestAsync(new ShareTextRequest
                {
                    Text = item.getShareText(),
                    Title = "Share Item"
                });
            };
*/


        }

        public override int ItemCount
        {
            get
            {
                return Items.Length;
            }
        }

    }
}
