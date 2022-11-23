using Lab8.Models;

namespace Lab8.Creator;

public static class RecordCreator
{
    public static Record CreateFrom(RecordViewModel viewModel)
    {
        return new Record
        {
            Id = viewModel.Id,
            Surname = viewModel.Surname,
            Phone = viewModel.Phone,
        };
    }

    public static Record CreateFrom(string id, RecordViewModel viewModel)
    {
        return new Record
        {
            Id = id,
            Surname = viewModel.Surname,
            Phone = viewModel.Phone,
        };
    }

    public static RecordViewModel CreateFrom(Record record)
    {
        return new RecordViewModel
        {
            Surname = record.Surname,
            Phone = record.Phone,
        };
    }
}