using System.Collections.Generic;
using System.Windows.Input;
using ZeBoneGame.Infra;
using ZeBoneGame.Model;
using System.Linq;
using System.Collections.ObjectModel;
using System;

namespace ImageSelector
{
    public class ImageSelectorViewModel : BindableBase
    {
        private Bone _currentBone;
        private List<Bone> _bones;
        private List<BoneImageVm> _images;
        private ObservableCollection<string> _favorites;
        private int _currentBoneIndex;

        public Bone CurrentBone {
            get => _currentBone;
            set
            {
                SetProperty(ref _currentBone, value, "CurrentBone");
                OnPropertyChanged("CurrentBoneIndex");
                Images = GetImages(value);
                _favorites.Clear();
            }

        }

        public int CurrentBoneIndex
        {
            get => _bones.IndexOf(_currentBone);
        }

        private List<BoneImageVm> GetImages(Bone value)
        {
            List<BoneImage> boneImages;
            // Open database(or reate if not exits)
            using (var db = Gr.GetLiteDb())
            {

                boneImages = new List<BoneImage>(
                    db.GetCollection<BoneImage>("boneImages").Find(i => i.BoneId == value.Id)
                    );
            }

           return boneImages.ConvertAll(b => new BoneImageVm(this, b));
        }

        public List<BoneImageVm> Images 
        {
            get => _images;
            set => SetProperty(ref _images, value, "Images");
        }

        public ImageSelectorViewModel()
        {
            _favorites = new ObservableCollection<string>();
            // Open database(or reate if not exits)
            using (var db = Gr.GetLiteDb())
            {
                _bones = new List<Bone>(db.GetCollection<Bone>("bones").FindAll());
                foreach (var bone in _bones)
                {
                    var whats = new List<WhatQuestion>(
                        db.GetCollection<WhatQuestion>("whatQuestions").Find(w => w.Answer == bone.Name)
                        );

                    if (whats.Count == 0)
                    {
                        CurrentBone = _bones[0];
                        break;
                    }
                }
            }

           

           
        }

        public ICommand AddFavorite => new RelayCommand<string>(s => AddFavoriteCommand(s));
        public ICommand Next => new RelayCommand(() => NextBoneCommand());

        private void NextBoneCommand()
        {
            using (var db = Gr.GetLiteDb())
            {
                var whatCollection = db.GetCollection<WhatQuestion>("whatquestions");
                WhatQuestion what = new WhatQuestion(CurrentBone.Name, Favorites.ToArray());
                whatCollection.Upsert(what);
                whatCollection.EnsureIndex("answer");

            }

            CurrentBone = _bones[_bones.IndexOf(_currentBone) + 1];
        }

        public void AddFavoriteCommand(string s)
        {

            if (_favorites.Contains(s))
                return;

            if(_favorites.Count() == 2)
                _favorites.RemoveAt(0);

            _favorites.Add(s);

            OnPropertyChanged("Favorites");
        }

        public IEnumerable<string> Favorites { get => _favorites; }


        public class BoneImageVm :BoneImage
        {
            private ImageSelectorViewModel _imageSelector;

            public BoneImageVm( ImageSelectorViewModel imageSelector, BoneImage boneImage)
            {
                _imageSelector = imageSelector;
                BoneId = boneImage.BoneId;
                FilePath = boneImage.FilePath;
            }

            public ICommand AddFavorite => new RelayCommand(AddFavoriteCmd);

            private void AddFavoriteCmd()
            {
                _imageSelector.AddFavoriteCommand(FilePath);
            }
        }
    }

}
