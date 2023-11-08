class Note
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }

    public Note(string title, string description, DateTime dueDate)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
    }
}
class DailyPlanner
{
    private List<Note> notes;
    private DateTime selectedDate;

    public DailyPlanner()
    {
        notes = new List<Note>();
        selectedDate = DateTime.Today;
    }

    public void AddNote(Note note)
    {
        notes.Add(note);
    }

    public void NextDate()
    {
        selectedDate = selectedDate.AddDays(1);
    }

    public void PreviousDate()
    {
        selectedDate = selectedDate.AddDays(-1);
    }

    public void ShowMenu()
    {
        Console.WriteLine($"Selected Date: {selectedDate.ToShortDateString()}\n");

        foreach (Note note in notes)
        {
            Console.WriteLine(note.Title);
        }
    }

    public void ShowNoteDetails(int index)
    {
        if (index >= 0 && index < notes.Count)
        {
            Note note = notes[index];
            Console.WriteLine($"Title: {note.Title}");
            Console.WriteLine($"Description: {note.Description}");
            Console.WriteLine($"Due Date: {note.DueDate}");
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        DailyPlanner planner = new DailyPlanner();

        // Добавим несколько заметок
        planner.AddNote(new Note("Заметка 1", "Описание заметки 1", DateTime.Today));
        planner.AddNote(new Note("Заметка 2", "Описание заметки 2", DateTime.Today.AddDays(1)));
        planner.AddNote(new Note("Заметка 3", "Описание заметки 3", DateTime.Today.AddDays(2)));

        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            planner.ShowMenu();
            Console.WriteLine("\nUse left and right arrow keys to navigate. Press Enter to view note details. Press Esc to exit.");

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    planner.PreviousDate();
                    break;
                case ConsoleKey.RightArrow:
                    planner.NextDate();
                    break;
                case ConsoleKey.Enter:
                    Console.WriteLine("\nEnter the index of the note to view details:");
                    if (int.TryParse(Console.ReadLine(), out int index))
                    {
                        Console.Clear();
                        planner.ShowNoteDetails(index);
                    }
                    break;
                case ConsoleKey.Escape:
                    isRunning = false;
                    break;
            }
        }
    }
}