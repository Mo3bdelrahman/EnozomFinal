using AutoMapper;
using EnozomFinal.Application.Contracts.IRepositories;
using EnozomFinal.Application.Contracts.IServices;
using EnozomFinal.Application.Models;
using EnozomFinal.Domain.Entities;
using FluentValidation;


namespace EnozomFinal.Application.Services
{
    public class BorrowingService : IBorrowingService
    {
        private readonly IMapper _mapper;
        private readonly IValidator<BorrowDto> _borrowDtoValidator;
        private readonly IValidator<ReturnDto> _returnDtoValidator;
        private readonly IBorrowingRepository _borrowingRepository;
        private readonly ICopyRepository _copyRepository;

        public BorrowingService(IMapper mapper,
                                IValidator<BorrowDto> borrowDtoValidator,
                                IValidator<ReturnDto> returnDtoValidator,
                                IBorrowingRepository borrowingRepository,
                                ICopyRepository copyRepository)
        {
            _mapper = mapper;
            _borrowDtoValidator = borrowDtoValidator;
            _returnDtoValidator = returnDtoValidator;
            _borrowingRepository = borrowingRepository;
            _copyRepository = copyRepository;
        }

        public async Task<string> BorrowBookCopy(BorrowDto borrowDto)
        {
            //check over data validation
            var validationResult = await _borrowDtoValidator.ValidateAsync(borrowDto);
            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);
          
            var bookCopy = await _copyRepository.GetCopyWithStatusByIdAsync(borrowDto.CopyId);

            //check if copy exist
            if (bookCopy == null)
                throw new Exceptions.NotFoundException("Book Copy Not Found");

            //check if copy status is good
            if (bookCopy.CopyStatusId == 4)
            {
                throw new Exceptions.BadRequestException("Book Copy already Borrowed");
            }
            else if (bookCopy.CopyStatusId != 1)
            {
                throw new Exceptions.BadRequestException("Book Status is Not Good");
            }


            var borrowing = _mapper.Map<StudentCopy>(borrowDto);
            borrowing.BorrowDate = DateTime.Now;
            borrowing.CopyStatusId = 1;
            var res = await _borrowingRepository.AddBorrowingAsync(borrowing);
            // check if borrowing added successfuly
            if (!res)
                throw new Exceptions.BadRequestException("Error While add Borrwing");

            //update book copy state
            bookCopy.CopyStatusId = 4;
            var copyRes = await _borrowingRepository.UpdateBorrowingAsync(borrowing);

            //check if book copy updated successfuly
            if (!copyRes)
                throw new Exceptions.BadRequestException("Error while Return");


            return "Sccessful Borrowing!";            
        }

        public async Task<string> ReturnBookCopy(ReturnDto returnDto)
        {
            //check over data validation
            var validationResult = await _returnDtoValidator.ValidateAsync(returnDto);
            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            var borrowing = await _borrowingRepository.GetBorrowingByIdAsync(returnDto.BorrowingId);

            //check if borrowing exist
            if (borrowing == null)
                throw new Exceptions.NotFoundException("Borrwing Not Found");

            var copy  = await _copyRepository.GetCopyWithStatusByIdAsync(borrowing.CopyId);

            //check if book copy exist
            if (copy == null)
                throw new Exceptions.BadRequestException("Error while Return");

            //check if book copy borrowed
            if (copy.CopyStatusId != 4)  //if i have time i'll search for other solution betar than magic number
                throw new Exceptions.BadRequestException("Book Copy already returned");



            borrowing.ReturnDate = DateTime.Now;
            borrowing.CopyStatusId = returnDto.StatusId;

            var borrowRes = await _borrowingRepository.UpdateBorrowingAsync(borrowing);

            //check if borrowing updated successfuly
            if (!borrowRes)
                throw new Exceptions.BadRequestException("Error while Return");

            if (returnDto.StatusId == 4)
            {
                throw new Exceptions.BadRequestException("Invalid statusId");
            }
            //update book copu state
            copy.CopyStatusId = returnDto.StatusId;
            var copyRes = await _borrowingRepository.UpdateBorrowingAsync(borrowing);

            //check if book copy updated successfuly
            if (!copyRes)
                throw new Exceptions.BadRequestException("Error while Return");

            return "Successful Return!";

        }
    }
}
