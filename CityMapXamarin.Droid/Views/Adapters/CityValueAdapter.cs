using System.Windows.Input;
using Android.Support.V7.Widget;
using Android.Views;
using CityMapXamarin.Droid.Views.ViewHolders;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using CityMapXamarin.Droid.Infrastructure;

namespace CityMapXamarin.Droid.Views.Adapters
{
    public class CityValueAdapter : MvxRecyclerAdapter
    {
       public ICommand CityItemClick { get; set; }
        private ShowCityMapDelegate _showCityMap;
        public CityValueAdapter(IMvxAndroidBindingContext bindingContext, ShowCityMapDelegate showCityMap) : base(bindingContext)
        {
            _showCityMap = showCityMap;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext?.LayoutInflaterHolder);
            var view = itemBindingContext.BindingInflate(Resource.Layout.city_list_item_template, parent, false);

            var viewHolder = new CityValueViewHolder(view, itemBindingContext, _showCityMap);
            viewHolder.CityClicked += (s, e) =>
            {
                CityItemClick.Execute(s);
            };

            return viewHolder;
        }
    }
}