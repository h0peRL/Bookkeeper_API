using Bookkeeper_API.Data;
using Bookkeeper_API.Data.DTOs;

namespace Bookkeeper_API.Model.Services
{
    public static class BookingRecordConverter
    {
        public static BookingRecord BookingDtoToBookingRecord(BookingDto bookingDto, IDataRepository dataRepository)
        {
            Account debitAccount = dataRepository.GetAccountById(bookingDto.DebitAccount);
            Account creditAccount = dataRepository.GetAccountById(bookingDto.CreditAccount);

            BookingRecord record = new (
                null,
                bookingDto.BookingNote,
                creditAccount,
                debitAccount,
                bookingDto.Amount);

            return record;
        }
    }
}
