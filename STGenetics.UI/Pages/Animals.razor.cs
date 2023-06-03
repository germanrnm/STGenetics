using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using STGenetics.Application.Animals.Commands.AddAnimal;
using STGenetics.Application.Animals.Commands.DeleteAnimal;
using STGenetics.Application.Animals.Commands.UpdateAnimal;
using STGenetics.Application.Animals.Queries.GetAnimals;
using STGenetics.Contracts.Animals;
using STGenetics.UI.Shared;
using System.Globalization;
using System.Xml.Linq;
using static MudBlazor.CategoryTypes;

namespace STGenetics.UI.Pages
{
    public partial class Animals
    {
        private bool isVisible;
        private GetAnimalResponse AnimalResponse;
        private GetAnimalResponse ElementBeforeEdit;
        private decimal TotalBeforeDiscount = 0;
        private decimal TotalAfterParticularDiscount = 0;
        private decimal TotalAfterGeneralDiscount = 0;
        private decimal TotalParticularDiscount = 0;
        private decimal TotalGeneralDiscount = 0;
        private decimal TotalDiscounts = 0;
        private decimal Freight = 0;
        private decimal Total = 0;
        private string searchString1 = "";
        private List<GetAnimalResponse> SelectedItems = new List<GetAnimalResponse>();
        private EditAnimalRequest AnimalModel = new EditAnimalRequest();
        public CultureInfo _en = CultureInfo.GetCultureInfo("en-US");
        private TableGroupDefinition<GetAnimalResponse> _groupDefinition = new()
        {
            GroupName = "Breed",
            Indentation = false,
            Expandable = true,
            IsInitiallyExpanded = false,
            Selector = (e) => e.Breed
        };
        public int EditOption;
        private string Error { get; set; } = null!;
        private IEnumerable<GetAnimalResponse> AnimalsResponse { get; set; } = new List<GetAnimalResponse>();
        [Inject]
        private IMapper Mapper { get; set; } = null!;
        [Inject]
        private ISender Mediator { get; set; } = null!;


        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        public async Task LoadData()
        {
            var query = new GetAnimalsQuery();
            var result = await Mediator.Send(query);
            if (result.IsError)
                Error = result.FirstError.Description;
            else
                AnimalsResponse = Mapper.Map<GetAnimalsResponse>(result.Value).Animals;
        }

        public async Task AddAnimal()
        {
            var command = Mapper.Map<AddAnimalCommand>(AnimalModel);
            var result = await Mediator.Send(command);
            if (result.IsError)
                SnackbarService.Add(result.FirstError.Description, Severity.Error);
            else
            {
                AnimalResponse = Mapper.Map<GetAnimalResponse>(result.Value);
                if (AnimalResponse.Id > 0)
                    SnackbarService.Add("Animal added successfully", Severity.Success);
                else
                    SnackbarService.Add("An error occurred while adding the Animal", Severity.Error);
            }
        }
        public async Task UpdateAnimal()
        {
            var command = Mapper.Map<UpdateAnimalCommand>(AnimalResponse);
            var result = await Mediator.Send(command);
            if (result.IsError)
                SnackbarService.Add("result.FirstError.Description", Severity.Error);
            else
            {
                AnimalResponse = Mapper.Map<GetAnimalResponse>(result.Value);
                if (AnimalResponse.Id > 0)
                    SnackbarService.Add("Animal updated successfully", Severity.Success);
                else
                    SnackbarService.Add("An error occurred while updating the Animal", Severity.Error);
            }
            await LoadData();
            StateHasChanged();
        }
        public async Task DeleteAnimal(int id)
        {
            var parameters = new DialogParameters
            {
                { "ContentText", "Do you really want to delete these record? This process cannot be undone." },
                { "ButtonText", "Delete" },
                { "Color", Color.Error }
            };

            var options = new DialogOptions() { CloseButton = false, MaxWidth = MaxWidth.ExtraSmall };

            var dialogresult = DialogService.Show<CustomDialog>("Delete", parameters, options);
            var res = await dialogresult.Result;
            if (!res.Cancelled && bool.TryParse(res.Data.ToString(), out bool resultbool))
            {
                var command = new DeleteAnimalCommand(id);
                var result = await Mediator.Send(command);
                if (result.IsError)
                    SnackbarService.Add(result.FirstError.Description, Severity.Error);
                else {
                    if (result.Value)
                        SnackbarService.Add("Animal deleted successfully", Severity.Success);
                    else
                        SnackbarService.Add("Unexpected error while deleting", Severity.Error);
                }
                await LoadData();
                StateHasChanged();
            }
        }
        public void EditForm(int value)
        {
            EditOption = value;
            isVisible = true;
        }

        public void CloseEditForm()
        {
            AnimalModel = new EditAnimalRequest();
            isVisible = false;
        }
        private async Task OnValidSubmit(EditContext context)
        {
            await AddAnimal();
            CloseEditForm();
            await LoadData();
            StateHasChanged();
        }

        private void BackupItem(object element)
        {
            ElementBeforeEdit = new()
            {
                Id = ((GetAnimalResponse)element).Id,
                Name = ((GetAnimalResponse)element).Name,
                Breed = ((GetAnimalResponse)element).Breed,
                BirthDate = ((GetAnimalResponse)element).BirthDate,
                Sex = ((GetAnimalResponse)element).Sex,
                Price = ((GetAnimalResponse)element).Price,
                Status = ((GetAnimalResponse)element).Status
            };
        }

        private void ResetItemToOriginalValues(object element)
        {
            ((GetAnimalResponse)element).Id = ElementBeforeEdit.Id;
            ((GetAnimalResponse)element).Name = ElementBeforeEdit.Name;
            ((GetAnimalResponse)element).Breed = ElementBeforeEdit.Breed;
            ((GetAnimalResponse)element).BirthDate = ElementBeforeEdit.BirthDate;
            ((GetAnimalResponse)element).Sex = ElementBeforeEdit.Sex;
            ((GetAnimalResponse)element).Price = ElementBeforeEdit.Price;
            ((GetAnimalResponse)element).Status = ElementBeforeEdit.Status;
        }

        private void ChekedChange(int id, bool value)
        {
            GetAnimalResponse selectedItem = AnimalsResponse.First(x => x.Id == id);
            selectedItem.Selected = value;
            if (selectedItem != null)
            {
                if (selectedItem.Selected)
                {
                    if (!SelectedItems.Contains(selectedItem))
                    {
                        SelectedItems.Add(selectedItem);
                    }
                }
                else
                {
                    if (SelectedItems.Contains(selectedItem))
                    {
                        SelectedItems.Remove(selectedItem);
                    }
                }

                if (SelectedItems.FindIndex(x => x.Id == selectedItem.Id) > 4)
                {
                    selectedItem.Discount = selectedItem.Price * (decimal)0.05;
                    selectedItem.FinalPrice = selectedItem.Price - selectedItem.Discount;
                }
                else
                {
                    selectedItem.Discount = 0;
                    selectedItem.FinalPrice = selectedItem.Price;
                }
            }

            SelectedItems.Where(x => SelectedItems.FindIndex(i => i.Id == x.Id) > 4)
                         .ToList().ForEach(x =>
                         {
                             x.Discount = x.Price * (decimal)0.05;
                             x.FinalPrice = x.Price - x.Discount;
                         });
            SelectedItems.Where(x => SelectedItems.FindIndex(i => i.Id == x.Id) <= 4)
                         .ToList().ForEach(x =>
                         {
                             x.Discount = 0;
                             x.FinalPrice = x.Price;
                         });
            TotalBeforeDiscount = SelectedItems.Sum(x => x.Price);
            TotalParticularDiscount = SelectedItems.Sum(x => x.Discount);
            TotalAfterParticularDiscount = SelectedItems.Sum((x) => x.FinalPrice);
            if (SelectedItems.Count > 10)
                TotalGeneralDiscount = TotalAfterParticularDiscount * (decimal)0.03;
            else
                TotalGeneralDiscount = 0;
            TotalAfterGeneralDiscount = TotalAfterParticularDiscount - TotalGeneralDiscount;
            TotalDiscounts = TotalParticularDiscount + TotalGeneralDiscount;
            Freight = (SelectedItems.Count > 20 || SelectedItems.Count == 0) ? 0 : 1000;
            Total = TotalBeforeDiscount - TotalDiscounts + Freight;
        }

        private void DateChanged(DateTime date, GetAnimalResponse element)
        {
            this.SetDateTime(date, element.BirthDate.TimeOfDay, element);
        }

        private void SetDateTime(DateTime date, TimeSpan time, GetAnimalResponse element)
        {
            element.BirthDate = new DateTime(date.Year, date.Month, date.Day, time.Hours, time.Minutes, time.Seconds);
        }

        private bool FilterFunc1(GetAnimalResponse element) => FilterFunc(element, searchString1);

        private bool FilterFunc(GetAnimalResponse element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if ($" {element.Name} {element.Breed} {element.Price} {element.Sex} {element.Status}".Contains(searchString))
                return true;
            if (element.BirthDate.ToString("MM/dd/yyyy").Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
    }
}
