using System;
using Lab3.ViewModels;
using Models.Models;

namespace Lab3.Creators
{
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
}