using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Blank.Views.Cell;
using CityMapXamarin.Core.Models;
using Foundation;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace Blank.Views.CollectionSource
{
    public class CitiesCollectionSource : MvxCollectionViewSource
    {
        public CitiesCollectionSource(UICollectionView collectionView) : base(collectionView)
        {
            collectionView.RegisterNibForCell(CityViewCell.Nib, CityViewCell.Key);
        }

        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            base.ItemSelected(collectionView, indexPath);
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cityCell = (CityViewCell)collectionView.DequeueReusableCell(CityViewCell.Key, indexPath);
            var cities = ItemsSource as IEnumerable<CityModel>;
            cityCell.Name.Text = cities.ElementAt(indexPath.Row).Name;
            cityCell.ImageView.Image = GetIamge(cities.ElementAt(indexPath.Row).FilePath);

            var singleTap = new UITapGestureRecognizer((s) =>
            {
                SelectionChangedCommand.Execute(cities.ElementAt(indexPath.Row));
            });
            cityCell.UserInteractionEnabled = true;
            cityCell.AddGestureRecognizer(singleTap);


            return cityCell;
        }

        public override bool ShouldHighlightItem(UICollectionView collectionView, NSIndexPath indexPath)
        {
            return false;
        }
        protected override UICollectionViewCell GetOrCreateCellFor(UICollectionView collectionView, NSIndexPath indexPath, object item)
        {
            return base.GetOrCreateCellFor(collectionView, indexPath, item);
        }

        private UIImage GetIamge(string path)
        {
            if(string.IsNullOrEmpty(path))
            {
                return null;
            }
            var docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var jpegData = NSData.FromFile(Path.Combine(docsPath,path));
            if (jpegData == null)
            {
                return null;
            }
            return UIImage.LoadFromData(jpegData);
        }
    }
}

