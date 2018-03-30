using MahApps.Metro.Controls;
using OrpSkuViewer.Presentation;
using OrpSkuRepository.Sql;

namespace OrpSkuViewer.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private SqlRepository _sqlRepo;
        private OrpSkuViewerViewModel _viewModel;

        public MainWindow( )
        {
            InitializeComponent();
            _sqlRepo = new SqlRepository();
            _viewModel = new OrpSkuViewerViewModel(_sqlRepo);
            DataContext = _viewModel;
        }
    }
}
