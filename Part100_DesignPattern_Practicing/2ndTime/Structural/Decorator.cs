using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part100_DesignPattern_Practicing._2ndTime.Structural
{
    // Real life analogy: view video in youtube with content video is base 
    // and then we have many options for it : video quality options , subtitle, playback speed, save your playlist for watching later.... 
    // it includes 4 parts
    //1. Component interface: define common interface , specifies operations that can be performed on the objects
    //2. Concreate component: implenment Component interface. They are the objects to which we want to add new behavior or responsibility
    //3. Decorator: abtract class also implement Component interface and have a reference to component object. Responsible for adding new behaviors to the wrapped component object.
    //4. Concrete Decorator: extend Decorator class . Add specific behaviors to the Component. It can add one or more behaviors to the component
    public interface IVideoComponent
    {
        void PlayVideo();
    }

    public class Mp3Video : IVideoComponent
    {
        public void PlayVideo()
        {
            Console.WriteLine("Playing mp3 video");
        }
    }

    public class Mp4Video : IVideoComponent
    {
        public void PlayVideo()
        {
            Console.WriteLine("Playing mp4 video");
        }
    }

    public abstract class VideoDecorator : IVideoComponent
    {
        private IVideoComponent _videoComponent;
        protected VideoDecorator(IVideoComponent videoComponent)
        {
            _videoComponent = videoComponent;
        }

        public virtual void PlayVideo()
        {
            _videoComponent.PlayVideo();
        }
    }

    public class HighQualityVideoDecorator : VideoDecorator
    {
        public HighQualityVideoDecorator(IVideoComponent videoComponent) : base(videoComponent)
        {
        }

        public override void PlayVideo()
        {
            base.PlayVideo();
            Console.WriteLine("Play video with highest quality");
        }
    }

    public class SpeedVideoDecorator : VideoDecorator
    {
        public SpeedVideoDecorator(IVideoComponent videoComponent) : base(videoComponent)
        {
        }

        public override void PlayVideo()
        {
            base.PlayVideo();
            Console.WriteLine("Play video with high speed for saving time in learning");
        }
    }

    public class AddPlaylistsVideoDecorator : VideoDecorator
    {
        public AddPlaylistsVideoDecorator(IVideoComponent videoComponent) : base(videoComponent)
        {
        }

        public override void PlayVideo()
        {
            base.PlayVideo();
            Console.WriteLine("You have added this video for later watching");
        }
    }

}
