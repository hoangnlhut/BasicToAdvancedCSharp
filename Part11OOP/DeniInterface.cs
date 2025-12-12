using Part11_12OOP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part11_12OOP
{
    interface IStorable
    {
        void Read();
        void Write();
    }

    interface ITalk
    {
        void Read();
        void Hide();
    }

    // lớp Document đơn giản thực thi giao diện IStorable
    public class Document : IStorable, ITalk
    {
        // bộ khởi dựng
        public Document(string s)
        {
            Console.WriteLine("Creating document with: {0}", s);
        }
        // đánh dấu phương thức Read ảo
        public virtual void Read()
        {
            Console.WriteLine("Document Read Method for IStorable");
        }

        void ITalk.Read()
        {
            Console.WriteLine("Document Read Method for ITalk");
        }

        void ITalk.Hide()
        {
            Console.WriteLine("Document Hide Method for ITalk");
        }


        // không phải phương thức ảo
        public void Write()
        {
            Console.WriteLine("Document Write Method for IStorable");
        }
    }

    // lớp dẫn xuất từ Document
    public class Note : Document
    {
        public Note(string s) : base(s)
        {
            Console.WriteLine("Creating note with: {0}", s);
        }
        // phủ quyết phương thức Read()
        public override void Read()
        {
            Console.WriteLine("Overriding the Read Method for Note!");
        }
        // thực thi một phương thức Write riêng của lớp
        public void Write()
        {
            Console.WriteLine("Implementing the Write method for Note!");
        }
    }

    public static class DeniInterface
    {
        public static void Run()
        {
            // tạo một đối tượng Document
            Document theNote = new Note("Test Note");
            IStorable isNote = theNote as IStorable;
            if (isNote != null)
            {
                isNote.Read();
                isNote.Write();
            }

            ITalk isTalk = theNote as ITalk;
            if (isTalk != null)
            {
                isTalk.Read();
                isTalk.Hide();
            }

            Console.WriteLine("\n");
            // trực tiếp gọi phương thức
            theNote.Read();
            theNote.Write();
            Console.WriteLine("\n");
            // tạo đối tượng Note
            Note note2 = new Note("Second Test");
            IStorable isNote2 = note2 as IStorable;
            if (isNote2 != null)
            {
                isNote2.Read();
                isNote2.Write();
            }
            Console.WriteLine("\n");
            // trực tiếp gọi phương thức
            note2.Read();
            note2.Write();
        }
    }
}
