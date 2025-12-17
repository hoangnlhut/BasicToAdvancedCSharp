namespace Part98_Delegate_And_Event.ImageProcess
{
    // lớp xử lý ảnh
    public class ImageProcessor
    {
        // khai báo ủy quyền
        public delegate void DoEffect();
        // biến thành viên
        private DoEffect[] arrayOfEffects;
        private Image image;
        private int numEffectsRegistered = 0;


        // tạo các ủy quyền tĩnh
        public DoEffect BlurEffect = new DoEffect(Blur);
        public DoEffect SharpenEffect = new DoEffect(Sharpen);
        public DoEffect FilterEffect = new DoEffect(Filter);
        public DoEffect RotateEffect = new DoEffect(Rotate);
        // bộ khởi dựng khởi tạo ảnh và mảng
        public ImageProcessor(Image image)
        {
            this.image = image;
            arrayOfEffects = new DoEffect[10];
        }
        // thêm hiệu ứng vào trong mảng
        public void AddToEffects(DoEffect theEffect)
        {
            //if (numEffectsRegistered >= 0)
            //{
            //    throw new Exception("Too many members in array");
            //}
            arrayOfEffects[numEffectsRegistered++] = theEffect;
        }
        // các phương thức xử lý ảnh
        public static void Blur()
        {
            Console.WriteLine("Blurring image");
        }
        public static void Filter()
        {
            Console.WriteLine("Filtering image");
        }
        public static void Sharpen()
        {
            Console.WriteLine("Sharpening image");
        }
        public static void Rotate()
        {
            Console.WriteLine("Rotating image");
        }
        // gọi các ủy quyền để thực hiện hiệu ứng
        public void ProcessImage()
        {
            for (int i = 0; i < numEffectsRegistered; i++)
            {
                arrayOfEffects[i]();
            }
        }
        
    }

    // khai báo lớp ảnh
    public class Image
    {
        public Image()
        {
            Console.WriteLine("An image created");
        }
    }

}
    
