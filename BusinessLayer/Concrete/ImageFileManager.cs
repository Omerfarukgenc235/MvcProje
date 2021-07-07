﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _imageDal;

        public ImageFileManager(IImageFileDal imageDal)
        {
            _imageDal = imageDal;
        }

        public void Ekle(ImageFile imageFile)
        {
            _imageDal.Insert(imageFile);
        }

        public List<ImageFile> GetList()
        {
            return _imageDal.List();
        }
    }
}
