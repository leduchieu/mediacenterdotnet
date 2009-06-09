using System;

using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.Collections.Generic;

namespace ProjectDOTNET
{
    /// <summary>Esta clase guarda el path, el path convertido a Uri y un imagen
    /// <param name="path">Sirve para indicar el path a la imagen</param>
    /// </summary>
    public class ImageFile
    {
        public ImageFile(string path)
        {
            _path = path;
            _uri = new Uri(_path);
            _image = BitmapFrame.Create(_uri);
        }

        public override string ToString()
        {
            return Path;
        }

        public string FileName()
        {
            string[] substrings;
            char[] splitter = { '\\' };
            substrings = Path.Split(splitter);
            return substrings[substrings.Length - 1];
        }

        private String _path;
        public String Path { get { return _path; } }
        private Uri _uri;
        public Uri Uri { get { return _uri; } }
        private BitmapFrame _image;
        public BitmapFrame Image { get { return _image; } }
    }

    /// <summary>Esta clase guarda el path y el path convertido a Uri de un archivo de música
    /// <param name="path">Sirve para indicar el path a la cancion</param>
    /// </summary>
    public class MusicFile
    {
        public MusicFile(string path)
        {
            _path = path;
            _uri = new Uri(_path);
        }

        public override string ToString()
        {
            string[] substrings;
            char[] splitter = { '\\' };
            substrings = Path.Split(splitter);
            return substrings[substrings.Length - 1];
        }

        private String _path;
        public String Path { get { return _path; } }
        private Uri _uri;
        public Uri Uri { get { return _uri; } }
    }

    /// <summary>Esta clase guarda el path y el path convertido a Uri de un archivo de video
    /// <param name="path">Sirve para indicar el path al video</param>
    /// </summary>
    public class VideoFile
    {
        public VideoFile(string path)
        {
            _path = path;
            _uri = new Uri(_path);
        }

        public override string ToString()
        {
            string[] substrings;
            char[] splitter = { '\\' };
            substrings = Path.Split(splitter);
            return substrings[substrings.Length - 1];
        }

        private String _path;
        public String Path { get { return _path; } }
        private Uri _uri;
        public Uri Uri { get { return _uri; } }
    }

    /// <summary>Esta clase es una coleccion de archivos ImageFile
    /// <param name="path">Sirve para indicar el path al directorio de fotos</param>
    /// </summary>
    public class PhotoList : ObservableCollection<ImageFile>
    {
        public PhotoList() { }

        public PhotoList(string path) : this(new DirectoryInfo(path)) { }

        public PhotoList(DirectoryInfo directory)
        {
            _directory = directory;
            Update();
        }

        public string Path
        {
            set
            {
                _directory = new DirectoryInfo(value);
                Update();
            }
            get { return _directory.FullName; }
        }

        public DirectoryInfo Directory
        {
            set
            {
                _directory = value;
                Update();
            }
            get { return _directory; }
        }
        private void Update()
        {
            foreach (FileInfo f in _directory.GetFiles("*.jpg"))
            {
                Add(new ImageFile(f.FullName));
            }
            foreach (FileInfo f in _directory.GetFiles("*.png"))
            {
                Add(new ImageFile(f.FullName));
            }
            foreach (FileInfo f in _directory.GetFiles("*.gif"))
            {
                Add(new ImageFile(f.FullName));
            }
        }

        DirectoryInfo _directory;
    }

    /// <summary>Esta clase es una coleccion de archivos MusicFile
    /// <param name="path">Sirve para indicar el path al directorio de canciones</param>
    /// </summary>
    public class MusicList : ObservableCollection<MusicFile>
    {
        public MusicList() { }

        public MusicList(string path) : this(new DirectoryInfo(path)) { }

        public MusicList(DirectoryInfo directory)
        {
            _directory = directory;
            Update();
        }

        public string Path
        {
            set
            {
                _directory = new DirectoryInfo(value);
                Update();
            }
            get { return _directory.FullName; }
        }

        public DirectoryInfo Directory
        {
            set
            {
                _directory = value;
                Update();
            }
            get { return _directory; }
        }
        private void Update()
        {
            foreach (FileInfo f in _directory.GetFiles("*.mp3"))
            {
                Add(new MusicFile(f.FullName));
            }
            foreach (FileInfo f in _directory.GetFiles("*.wav"))
            {
                Add(new MusicFile(f.FullName));
            }
            foreach (FileInfo f in _directory.GetFiles("*.wma"))
            {
                Add(new MusicFile(f.FullName));
            }
        }

        DirectoryInfo _directory;
    }

    /// <summary>Esta clase es una coleccion de archivos de Video
    /// <param name="path">Sirve para indicar el path al directorio de videos</param>
    /// </summary>
    public class VideoList : ObservableCollection<VideoFile>
    {
        public VideoList() { }

        public VideoList(string path) : this(new DirectoryInfo(path)) { }

        public VideoList(DirectoryInfo directory)
        {
            _directory = directory;
            Update();
        }

        public string Path
        {
            set
            {
                _directory = new DirectoryInfo(value);
                Update();
            }
            get { return _directory.FullName; }
        }

        public DirectoryInfo Directory
        {
            set
            {
                _directory = value;
                Update();
            }
            get { return _directory; }
        }
        private void Update()
        {
            foreach (FileInfo f in _directory.GetFiles("*.wmv"))
            {
                Add(new VideoFile(f.FullName));
            }
            foreach (FileInfo f in _directory.GetFiles("*.mpg"))
            {
                Add(new VideoFile(f.FullName));
            }
            foreach (FileInfo f in _directory.GetFiles("*.avi"))
            {
                Add(new VideoFile(f.FullName));
            }
        }

        DirectoryInfo _directory;
    }

    /// <summary>Esta clase es una coleccion de objetos Telefono (base de datos)
    /// <param name="dataDc">Sirve para indicar el DataContext</param>
    /// </summary>
    public class ObservableTelefono : ObservableCollection<Telephones>
    {
        public ObservableTelefono( List <Telephones> dataDc)
        {
            foreach (Telephones thisTel in dataDc)
            {
                this.Add(thisTel);
            }
        }
    }

}
