using System;
using Lab3.Models;
using Lab3.ViewModels;

namespace Lab3.Creators
{
    public static class RecordCreator
    {
        public static Record CreateFrom(RecordViewModel viewModel)
        {
            return new Record
            {
                 Id = Guid.NewGuid().ToString(),
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
}