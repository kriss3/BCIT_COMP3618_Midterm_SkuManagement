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
    /// <summary>
    /// BCIT COMP3618 
    /// Krzysztof Szczurowski Midterm Project
    /// Repo: https://github.com/kriss3/BCIT_COMP3618_Midterm_SkuManagement.git
    /// Description: viewModel locator class to help assign data contex to xaml form (SKU Overview or SKU DetailView)
    /// Context binding is in xaml using declarative language, DataContext
    /// </summary>
    public class ViewModelLocator
    {
        private static IDialogService _dialogService = new DialogService();
        private static ISkuRepository _skuRepository = new SqlRepository();
        private static OrpSkuViewerDetailViewModel _skuViewDetailViewModel = new OrpSkuViewerDetailViewModel(_skuRepository, _dialogService);


        public static OrpSkuViewerViewModel SkuViewModel { get; } = new OrpSkuViewerViewModel(_skuRepository, _dialogService);

        public static OrpSkuViewerDetailViewModel SkuViewDetailViewModel
        {
            get
            {
                return _skuViewDetailViewModel;
            }
        }
    }
}
