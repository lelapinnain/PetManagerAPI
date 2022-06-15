using Microsoft.EntityFrameworkCore;
using PetManager.DTOs.InputDTOs;
using PetManager.Utilities.Paging;

namespace PetManager.Models.Quereies
{
    public class GetInvoicesAllQuery:AbstractQuery<PagedList<InvoicesListView>>
    {
        private readonly CoreDbContext db;
        private PagedList<InvoicesListView>? invoiceList;
        private PagingParams _pagingDTO;
      
        public GetInvoicesAllQuery(PagingParams pagingDTO)
        {
            db = new CoreDbContext();
            _pagingDTO = pagingDTO;
            invoiceList = null;
        }

        public async override Task<string> RunQuery()
        {
            var query =  db.InvoicesListViews.AsQueryable();
           invoiceList= await PagedList<InvoicesListView>.CreateAsync(query, _pagingDTO.PageNumber, _pagingDTO.PageSize);

            // invoiceList = await db.InvoicesListViews.ToListAsync();
            return ("");
        }

        public override PagedList<InvoicesListView> GetResult()
        {
            return invoiceList;
        }
    }
}
