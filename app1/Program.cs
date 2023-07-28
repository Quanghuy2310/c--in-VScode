using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


// collections trong C# là các lớp hỗ trợ lưu trữ, quản lý và thao tác các đối tượng một cách có thứ tự
// các lớp nằm trong C#
// Đặc điểm : collections là một mảng có kích thước động
// không cần khai báo kích thước khi khởi tạo
// có thể tăng giảm số lượng phần tử trong mảng một cách linh hoạt
// có thể lưu trữ một tập hợp đối tượng nhiều kiểu khác nhau
// hỗ trợ rất nhiều phương thức để thao tác với tập hợp như : tìm kiếm, sắp xếp, đảo ngược, thêm, xóa, sửa
// mỗi collections được tổ chức thành một lớp nên cần khởi tạo đối tượng trước khi sử dụng

namespace App
{
    class MainClass
    {
        // store dưới dạng Key - Value. khi truy xuất thông qua Key, thay vì thông qua chỉ số phần tử
        static Hashtable? userInfoHash;
        public static void Main(string[] args)
        {
                    Console.OutputEncoding = Encoding.UTF8;


            //Trong Hashtable chúng ta có thể thêm Items / Values với Keys
            userInfoHash = new Hashtable();
            // adding 
            for (int i = 0; i < 10; i++)
            {
                userInfoHash.Add(i, "user" + i);
            }
            // removing
            if (userInfoHash.ContainsKey(0))
            {
                userInfoHash.Remove(0);
            }

            // setting
            if (userInfoHash.ContainsKey(1))
            {
                userInfoHash[1] = "replacementName";
            }

            //Looping
            foreach (DictionaryEntry entry in userInfoHash)
            {
                System.Console.WriteLine("Key :" + entry.Key + " / Value :" + entry.Value);
            }

            // Stack cho phép lưu trữ và thao tác dữ liệu theo cấu trúc LIFO ( last in first out)
            // tạo 1 stack rỗng
            Stack MyStack = new Stack();
            // tạo thêm và gán range = 5
            Stack MyStack2 = new Stack(5);
            // tạo 1 mảng bất kỳ
            ArrayList stackArray = new ArrayList();
            stackArray.Add(1);
            stackArray.Add(2);
            stackArray.Add(3);
            stackArray.Add(4);
            // tạo stack , sao chép giá trị từ MyArray
            Stack MyStack3 = new Stack(stackArray);

            Stack newStack = new Stack();
            //thêm phần tử bằng Push
            newStack.Push("Máy tính");
            newStack.Push("Điện Thoại");
            newStack.Push("LapTop");
            Console.WriteLine(" Số phần tử hiện tại trong stack là : {0}", newStack.Count);
            Console.WriteLine(" Phần tử Đầu hiện tại trong stack là : {0}", newStack.Peek());
            // xóa
            int Length = newStack.Count;
            for (int i = 0; i < Length; i++)
            {
                Console.WriteLine("" + newStack.Pop());
            }
            Console.WriteLine("Sau khi xóa còn lại {0}", newStack.Count);


            // Queue cho phép lưu trữ và thao tác theo cấu trúc FIFO ( first in first out)

            Queue myQueue = new Queue();
            myQueue.Enqueue("1st");
            myQueue.Enqueue("2nd");
            myQueue.Enqueue("3rd");
            myQueue.Enqueue("4th");
            Console.WriteLine(" Số phần tử hiện tại trong Queue là : {0}", myQueue.Count);
            Console.WriteLine(" Phần tử Đầu hiện tại trong Queue là : {0}", myQueue.Peek());

            int LengthQueue = myQueue.Count;
            for (int i = 0; i < LengthQueue; i++)
            {
                Console.WriteLine("" + myQueue.Dequeue());
            }
            Console.WriteLine("Sau khi xóa còn lại {0}", myQueue.Count);


            // BitArray lưu trữ và quản lý list các bit, giống mảng các phần tử kiểu bool với true biểu thị cho
            // bit 1 và false cho bit 0. có hỗ trợ việc tính toán cho bit
            byte[] MyBytes = new Byte[5] { 1, 2, 3, 4, 5};
            BitArray myBA1 = new BitArray(MyBytes);
            // Kiểm thử
            Console.WriteLine("Số bits của BitArray là {0}", myBA1.Length);

            int[] MyInts = new int[5] { 1, 2, 3, 4, 5};
            BitArray myBA = new BitArray(MyInts); 
            Console.WriteLine("Số bits của BitArray la {0}", myBA.Length);   

            // tạo 1 Bitarray có 10 phần tử, giá trị fixed 1 (true)
            BitArray myBA2 = new BitArray(10, true);
            // tạo 1 Bitarray từ mảng bool có sẵn
            bool[] myBools = new bool[5] { true, false, true, true, false};
            BitArray myBA3 = new BitArray(myBools);

            byte[] myBytes = new byte[5] { 1, 2, 3, 4, 5};
            BitArray myBA4 = new BitArray(myBytes);

            Console.WriteLine("So bits cua BitArray la {0}", myBA4.Length);

            int[] myInts = new int[5]{1,2,3,4,5};
            BitArray myBA5 = new BitArray(myInts); 
            Console.WriteLine("So bits cua BitArray la {0}", myBA5.Length);

            // ArrayList cho phép store và manage các phần tử trong mảng. 
            //    Flex to add or delete và có thể edit kích cỡ một cách tự động
            string[] myArray = new string[7];
            myArray[0] = "Monday";
            myArray[1] = "Tuesday";
            myArray[2] = "Wednesday";
            myArray[3] = "Thursday";
            myArray[4] = "Friday";
            myArray[5] = "Saturday";
            myArray[6] = "Sunday";

            for (int i = 0; i < myArray.Length; i++)
            {
                Console.WriteLine(myArray[i]);
            }
            //Arraylist có thể chứa bất kỳ kiểu dữ liệu nào, array có thể lưu trữ mọi số lượng của items
            //Trong Arraylist chúng ta chỉ có thể thêm Items / Values vào list
            //List gồm các Items. 

            List<string> list = new List<string>();
            list.Add("Monday");
            list.Add("Tuesday");
            list.Add("Wednesday");
            list.Add("Thursday");
            list.Add("Friday");
            list.Add("Saturday");
            list.Add("Sunday");

            for (int i = 0; i < list.Count; i++)
            {
                list[i] = list[i].Substring(0, 3);
                System.Console.WriteLine(list[i]);
            }

            List<string> clothes = new List<string>();
            clothes.Add("Shirt");
            clothes.Add("Hat");
            clothes.Add("Shoes");

            foreach (var clothesItems in clothes)
            {
                System.Console.WriteLine(clothesItems);

            }


            //Dictionary gồm các cặp Key , Value. 
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary[0] = "Monday";
            dictionary[1] = "Tuesday";
            dictionary[2] = "Wednesday";
            dictionary[3] = "Thursday";
            dictionary[4] = "Friday";
            dictionary[5] = "Saturday";
            dictionary.Add(6, "Sunday");

            for (int i = 0; i < dictionary.Count; i++)
            {
                dictionary[i] = dictionary[i].Substring(0, 6);
                System.Console.WriteLine(dictionary[i]);
            }

            Dictionary<int, string> gender = new Dictionary<int, string>();
            gender.Add(1, "Man");
            gender.Add(2, "Woman");

            foreach (KeyValuePair<int, string> genders in gender)
            {
                System.Console.WriteLine($"{genders.Key} {genders.Value}");
            }
        }
    }


}

// SortedList sự kết hợp của ArrayList và HashTable. Xuất data dưới dạng Key-Value. Truy xuât qua Key hoặc
// chỉ số phần tử, được sắp xếp theo giá trị Key.











