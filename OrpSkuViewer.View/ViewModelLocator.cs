using OrpSkuRepository.Interface;
using OrpSkuRepository.Sql;
using OrpSkuViewer.Service;
using OrpSkuViewer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrpSkuViewer.View
{
    public class ViewModelLocator
    {
        private static IDialogService _dialogService = new DialogService();
        private static ISkuRepository _skuRepository = new SqlRepository();

        private static OrpSkuViewerViewModel _skuViewModel = new OrpSkuViewerViewModel(_skuRepository, _dialogService);
        private static OrpSkuViewerDetailViewModel _skuViewDetailViewModel = new OrpSkuViewerDetailViewModel(_skuRepository, _dialogService);


        public static OrpSkuViewerViewModel SkuViewModel
        {
            get
            {
                return _skuViewModel;
            }
        }

        public static OrpSkuViewerDetailViewModel SkuViewDetailViewModel
        {
            get
            {
                return _skuViewDetailViewModel;
            }
        }
    }
}
