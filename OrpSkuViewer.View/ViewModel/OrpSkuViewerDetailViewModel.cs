using OrpSkuRepository.Interface;
using OrpSkuViewer.Service;
using OrpSkuViewer.SharedObjects;
using OrpSkuViewer.View.Messages;
using OrpSkuViewer.View.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OrpSkuViewer.ViewModel
{
    public class OrpSkuViewerDetailViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ISkuRepository _currentRepo;
        private IDialogService _dialogService;
        private OrpSku _selectedOrpSku;

        public OrpSku SelectedOrpSku
        {
            get { return _selectedOrpSku; }
            set
            {
                _selectedOrpSku = value;
                raisePropertyChanged("SelectedOrpSku");
            }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public OrpSkuViewerDetailViewModel(ISkuRepository skuRepo, IDialogService dialogService)
        {
            _currentRepo = skuRepo;
            _dialogService = dialogService;

            Messenger.Default.Register<OrpSku>(this, OnOrpSkuReceived);

            SaveCommand = new CustomCommand(saveOrpSku, canSaveOrpSku);
            DeleteCommand = new CustomCommand(deleteOrpSku, canDeleteOrpSku);
        }

        public void OnOrpSkuReceived(OrpSku receivedOrpSku)
        {
            SelectedOrpSku = receivedOrpSku;
        }

        #region Private Methods

        private void raisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Commands handlers

        private bool canSaveOrpSku(object orpSku)
        {
            return true;
        }

        private void saveOrpSku(object orpSku)
        {
            _currentRepo.UpdateSku(_selectedOrpSku.OrpSkuName, _selectedOrpSku);
            Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
        }

        private bool canDeleteOrpSku(object orpSku)
        {
            return true;
        }

        private void deleteOrpSku(object orpSku)
        {
            _currentRepo.DeleteSku(_selectedOrpSku.OrpSkuName);

            Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
        }

        #endregion

    }
}
