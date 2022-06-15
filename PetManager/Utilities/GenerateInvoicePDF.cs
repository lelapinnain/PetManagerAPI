using PetManager.Models;
using IronPdf;
using PetManager.Models.Quereies;

namespace PetManager.Utilities
{
    public class GenerateInvoicePDF : IUtility<PdfDocument>
    {
        private PdfDocument pdfDocument;
        private IViewRenderService viewRenderService;
        private int customerId;
        private int petId;
        private int invoiceId;

        public GenerateInvoicePDF(IViewRenderService _viewRenderService, int _customerId, int _petId, int _invoiceId)
        {
            viewRenderService = _viewRenderService;
            customerId = _customerId;
            petId = _petId;
            invoiceId = _invoiceId;
        }

        public async Task<PdfDocument> Execute()
        {
            InvoiceTemplateModel viewModel = new InvoiceTemplateModel();

            GetCustomerInfoByIDQuery getCustomerInfoByIDQuery = new GetCustomerInfoByIDQuery(customerId);
            await getCustomerInfoByIDQuery.RunQuery();
            viewModel.Customer = getCustomerInfoByIDQuery.GetResult();

            GetPetInfoByIDQuery getPetInfoByIDQuery = new GetPetInfoByIDQuery(petId);
            await getPetInfoByIDQuery.RunQuery();
            viewModel.PetInfo = getPetInfoByIDQuery.GetResult();

            GetInvoiceByIDQuery getInvoiceByIDQuery = new GetInvoiceByIDQuery(invoiceId);
            await getInvoiceByIDQuery.RunQuery();
            viewModel.Invoice = getInvoiceByIDQuery.GetResult();

            string result = viewRenderService.RenderToStringAsync("InvoiceTemplate", viewModel);

            IronPdf.HtmlToPdf Renderer = new IronPdf.HtmlToPdf();

            Renderer.PrintOptions.MarginBottom = 10;
            Renderer.PrintOptions.MarginTop = 10;
            Renderer.PrintOptions.MarginLeft = 10;
            Renderer.PrintOptions.MarginRight = 10;

            pdfDocument = Renderer.RenderHtmlAsPdf(result);

            return pdfDocument;
        }
    }
}
