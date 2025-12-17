namespace Part98_Delegate_And_Event.Event
{
    // khai báo lớp Clock lớp này sẽ phát ra các sự kiện
    public class Clock
    {
        private int hour;
        private int minute;
        private int second;
        // khai báo delegate mà các subscriber phải thực thi
        public delegate void SecondChangeHandler(object clock, TimeInfoEventArgs timeInformation);
        // sự kiện mà chúng ta đưa ra
        public event SecondChangeHandler OnSecondChange;
        // thiết lập đồng hồ thực hiện, sẽ phát ra mỗi sự kiện trong mỗi giây
        public void Run()
        {
            for (; ; )
            {
                // ngừng 10 giây
                Thread.Sleep(10);
                // lấy thời gian hiện hành
                DateTime dt = DateTime.Now;
                // nếu giây thay đổi cảnh báo cho subscriber
                if (dt.Second != second)
                {
                    // tạo TimeInfoEventArgs để truyền
                    // cho subscriber
                    TimeInfoEventArgs timeInformation =
                    new TimeInfoEventArgs(dt.Hour, dt.Minute, dt.Second);
                    // nếu có bất cứ lớp nào đăng ký thì cảnh báo
                    if (OnSecondChange != null)
                    {
                        OnSecondChange(this, timeInformation);
                    }
                }
                // cập nhật trạng thái
                second = dt.Second;
                minute = dt.Minute;
                hour = dt.Hour;
            }
        }
        
    }

    // lớp lưu giữ thông tin về sự kiện, trong trường hợp
    // này nó chỉ lưu giữ những thông tin có giá trị lớp clock
    public class TimeInfoEventArgs : EventArgs
    {
        public TimeInfoEventArgs(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }
        public readonly int hour;
        public readonly int minute;
        public readonly int second;
    }
    // lớp DisplayClock đăng ký sự kiện của clock.
    // thực thi xử lý sự kiện bằng cách hiện thời gian hiện hành
    public class DisplayClock
    {
        public void Subscribe(Clock theClock)
        {
            theClock.OnSecondChange += new Clock.SecondChangeHandler(TimeHasChanged);
        }
        public void TimeHasChanged(object theClock, TimeInfoEventArgs ti)
        {
            Console.WriteLine("Current Time: {0}:{1}:{2}", ti.hour.ToString(), ti.minute.ToString(), ti.second.ToString());
        }
    }
    // lớp đăng ký sự kiện thứ hai
    public class LogCurrentTime
    {
        public void Subscribe(Clock theClock)
        {
            theClock.OnSecondChange += new Clock.SecondChangeHandler(WriteLogEntry);
        }
        // thông thường phương thức này viết ra file
        // nhưng trong minh họa này chúng ta chỉ xuất
        // ra màn hình console mà thôi
        public void WriteLogEntry(object theClock, TimeInfoEventArgs ti)
        {
            Console.WriteLine("Logging to file: {0}:{1}:{2}", ti.hour.ToString(), ti.minute.ToString(), ti.second.ToString());
        }
    }

}


