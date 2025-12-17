namespace Part98_Delegate_And_Event
{
    // lớp Pair đơn giản lưu giữ 2 đối tượng
    public class Pair
    {
        // khai báo ủy quyền
        public delegate Comparison WhichIsFirst(object obj1, object obj2);
        // mảng lưu 2 đối tượng
        private object[] thePair = new object[2];
        // truyền hai đối tượng vào bộ khởi dựng
        public Pair(object firstObject, object secondObject)
        {
            thePair[0] = firstObject;
            thePair[1] = secondObject;
        }

        public override string ToString()
        {
            return thePair[0].ToString() + ", " + thePair[1].ToString();
        }

        // phương thức sắp xếp thứ tự của hai đối tượng
        // theo bất cứ tiêu chuẩn nào của đối tượng
        public void Sort(WhichIsFirst theDelegateFunc)
        {
            if (theDelegateFunc(thePair[0], thePair[1]) == Comparison.theSecondComesFirst)
            {
                object temp = thePair[0];
                thePair[0] = thePair[1];
                thePair[1] = temp;
            }
        }
        // phương thức sắp xếp hai đối tượng theo
        // thứ tự nghịch đảo lại tiêu chuẩn sắp xếp
        public void ReverseSort(WhichIsFirst theDelegateFunc)
        {
            if (theDelegateFunc(thePair[0], thePair[1]) == Comparison.theFirstComesFirst)
            {
                object temp = thePair[0];
                thePair[0] = thePair[1];
                thePair[1] = temp;
            }
        }
    }
}
