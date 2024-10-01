﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTube_Viewer.Models;

namespace YouTube_Viewer.Stores
{
    public class SelectedYouTubeViewerStore
    {
		private readonly YouTubeViewersStore _youTubeviewersStore;

		private YouTubeViewer? _selectedYouTubeViewer;

        public SelectedYouTubeViewerStore(YouTubeViewersStore youTubeviewersStore)
        {
            _youTubeviewersStore = youTubeviewersStore;
            _youTubeviewersStore.YouTubeViewersUpdated += YouTubeviewersStore_YouTubeViewersUpdated;
        }

        private void YouTubeviewersStore_YouTubeViewersUpdated(YouTubeViewer obj)
        {
            if (obj.Id ==SelectedYouTubeViewer?.Id)
            {
                SelectedYouTubeViewer = obj;
            }
        }

        

        public YouTubeViewer SelectedYouTubeViewer
        {
			get { 

				return _selectedYouTubeViewer;
			}
			set {

                _selectedYouTubeViewer = value;
				SelectedYouTubeViewerChanged?.Invoke();

			
			}
		}

		public event Action? SelectedYouTubeViewerChanged;	

	}
}
