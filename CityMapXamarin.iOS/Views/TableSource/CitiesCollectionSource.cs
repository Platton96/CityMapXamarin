using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blank.Views.Cell;
using Foundation;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace Blank.Views.TableSource
{
    public class CitiesCollectionSource : MvxCollectionViewSource
    {
        public CitiesCollectionSource(UICollectionView collectionView):base(collectionView)
        {
            collectionView.RegisterNibForCell(CityViewCell.Nib, CityViewCell.Key);
        }

        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            base.ItemSelected(collectionView, indexPath);
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, Foundation.NSIndexPath indexPath)
        {
            var animalCell = (CityViewCell)collectionView.DequeueReusableCell(CityViewCell.Key, indexPath);
            return animalCell;
        }
        public override void ItemHighlighted(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = collectionView.CellForItem(indexPath);
            cell.ContentView.BackgroundColor = UIColor.Yellow;
        }
        public override void ItemUnhighlighted(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = collectionView.CellForItem(indexPath);
            cell.ContentView.BackgroundColor = UIColor.White;
        }
        public override bool ShouldHighlightItem(UICollectionView collectionView, NSIndexPath indexPath)
        {
            return false;
        }
        protected override UICollectionViewCell GetOrCreateCellFor(UICollectionView collectionView, NSIndexPath indexPath, object item)
        {
            return base.GetOrCreateCellFor(collectionView, indexPath, item);
        }
    }
}