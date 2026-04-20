using System;

// Lớp đại diện cho 1 học sinh
public class Student
{
    public string Id { get; set; }
    public string Name { get; set; }

    public Student(string id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString()
    {
        return $"Student(Id: {Id}, Name: {Name})";
    }
}

// Lớp đại diện cho 1 phần tử (Node)
public class DoubleNode
{
    public Student student;
    public DoubleNode Prev;
    public DoubleNode Next;

    public DoubleNode(Student student)
    {
        this.student = student;
        Prev = null;
        Next = null;
    }
}

// Lớp quản lý danh sách liên kết đôi
public class DoubleLinkedList
{
    public DoubleNode? Head;
    public DoubleNode? Tail;

    public DoubleLinkedList()
    {
        Head = null;
        Tail = null;
    }

    // Thêm phần tử vào cuối (Add Last)
    public void AddLast(Student student)
    {
        DoubleNode newNode = new DoubleNode(student);

        if (Head == null)
        {
            Head = Tail = newNode;
            return;
        }

        Tail.Next = newNode;
        newNode.Prev = Tail;
        Tail = newNode;
    }

    // Đếm số node
    public int GetSize()
    {
        int count = 0;
        DoubleNode current = Head;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }

    // Xóa node theo Id
    public void RemoveNode(string studentId)
    {
        DoubleNode current = Head;
        while (current != null)
        {
            if (current.student.Id == studentId)
            {
                if (current == Head)
                {
                    Head = current.Next;
                    if (Head != null)
                        Head.Prev = null;
                }
                else if (current == Tail)
                {
                    Tail = current.Prev;
                    if (Tail != null)
                        Tail.Next = null;
                }
                else
                {
                    current.Prev.Next = current.Next;
                    current.Next.Prev = current.Prev;
                }
                return;
            }
            current = current.Next;
        }
    }

    // Chèn sau index
    public void InsertAfterIndex(int index, Student student)
    {
        if (index < 0 || index >= GetSize())
        {
            Console.WriteLine("Vị trí chèn không hợp lệ.");
            return;
        }

        DoubleNode newNode = new DoubleNode(student);
        DoubleNode current = Head;

        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }

        newNode.Next = current.Next;
        newNode.Prev = current;
        if (current.Next != null)
            current.Next.Prev = newNode;
        else
            Tail = newNode;
        current.Next = newNode;
    }

    // Đảo ngược danh sách
    public void Reverse()
    {
        DoubleNode current = Head;
        DoubleNode temp = null;

        while (current != null)
        {
            temp = current.Prev;
            current.Prev = current.Next;
            current.Next = temp;
            current = current.Prev;
        }

        if (temp != null)
        {
            Head = temp.Prev;
        }
    }

    // Duyệt từ đầu đến cuối
    public void PrintForward()
    {
        DoubleNode current = Head;
        Console.Write("Tiến: null <-> ");
        while (current != null)
        {
            Console.Write($"{current.student} <-> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }

    // Duyệt từ cuối về đầu
    public void PrintBackward()
    {
        DoubleNode current = Tail;
        Console.Write("Lùi: null <-> ");
        while (current != null)
        {
            Console.Write($"{current.student} <-> ");
            current = current.Prev;
        }
        Console.WriteLine("null");
    }
}

// Chương trình chính
class Program
{
    static void Main()
    {
        DoubleLinkedList list = new DoubleLinkedList();
        list.AddLast(new Student("250011459", "Hải"));
        list.AddLast(new Student("250011460", "Hoàng"));
        list.AddLast(new Student("250011461", "Duy"));

        list.PrintForward();
        list.PrintBackward();
    }
}
