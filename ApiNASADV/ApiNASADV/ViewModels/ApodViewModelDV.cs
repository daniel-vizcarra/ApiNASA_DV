using ApiNASADV.Models;
using ApiNASADV.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ApiNASADV.ViewModels
{
    public class ApodViewModelDV : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public ApodViewModelDV()
        {
            ChosenDate = DateTime.Now;
        }
        private DateTime dateTime;

        public DateTime ChosenDate
        {
            get { return dateTime; }
            set
            {
                if (value != dateTime)
                {
                    dateTime = value;
                    NotifyPropertyChanged();
                }
                _ = GetPictureOfTheDay(dateTime);
            }
        }
        //La diferencia entre title y Title es que title es un campo privado usado para guardar
        //el valor de title mientras que Title es una propiedad pública que proporciona acceso
        //al campo title y lanza el evento PropertyChanged cuando su valor cambia, lo que es usado
        //para el data binding y las notificaciones de cambio.
        //El getter retorna el valor del campo title mientras que el setter permite asignar un
        //nuevo valor al campo title.
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                if (value != title)
                {
                    title = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private Uri imageUri;
        public Uri ImageURI
        {
            get { return imageUri; }
            set
            {
                if (imageUri != value)
                {
                    imageUri = value;
                    NotifyPropertyChanged();
                }
            }


        }
        private string didactic;
        public string Didactic
        {
            get { return didactic; }
            set
            {
                if (didactic != value)
                {
                    didactic = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private ApodServiceDV service;
        public ApodServiceDV Service
        {
            get
            {
                if (service == null)
                {
                    service = new ApodServiceDV();
                }
                return service;
            }
        }
        private async Task GetPictureOfTheDay(DateTime day)
        {
            ApodDV dto = await Service.GetImage(day);
            if (dto == null)
            {
                ImageURI = new Uri("https://image.freepik.com/vector-gratis/error-404-no-encontradoefecto-falla_8024-5.jpg");
                Didactic = "";
                Title = "Intenta con otra fecha";
            }
            else
            {
                ImageURI = new Uri(dto.hdurl);
                Didactic = dto.explanation;
                Title = dto.title;
            }
        }




    }
}