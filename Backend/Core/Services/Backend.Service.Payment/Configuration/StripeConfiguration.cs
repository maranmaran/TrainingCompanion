using Backend.Service.Payment.Interfaces;
using Backend.Service.Payment.Models;
using Newtonsoft.Json;
using Stripe;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Backend.Service.Payment.Configuration
{
    public class StripeConfiguration : IStripeConfiguration
    {
        private readonly StripeSettings _stripeSettings;
        public StripeConfiguration(StripeSettings stripeSettings)
        {
            _stripeSettings = stripeSettings;
        }

        public async Task ConfigureProducts()
        {
            var productService = new ProductService();
            var products = await productService.ListAsync();

            var planService = new PlanService();
            var plans = await planService.ListAsync();

            foreach (var product in GetProducts().Products)
            {
                await this.AddProduct(productService, products, product);

                var productId = product.Id ?? products.First(x =>
                                    x.Name.Equals(product.Name, StringComparison.InvariantCultureIgnoreCase)).Id;

                foreach (var plan in product.Plans)
                {
                    await this.AddPlan(planService, plans, plan, productId);
                }
            }
        }

        public async Task<string> AddCustomer(string fullName, string email)
        {
            var customerService = new CustomerService();
            var customer = await customerService.CreateAsync(new CustomerCreateOptions()
            {
                Email = email,
                Name = fullName,
            });

            return customer.Id;
        }

        /// <summary>
        /// Gets serialized model of products from Products.json
        /// </summary>
        /// <returns></returns>
        private static ProductsViewModel GetProducts()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                       + "/Configuration/Products.json";

            var data = System.IO.File.ReadAllText(path);
            return JsonConvert.DeserializeObject<ProductsViewModel>(data);
        }

        /// <summary>
        /// Adds specified product to stripe if it doesn't exist
        /// </summary>
        private async Task AddProduct(ProductService productService, StripeList<Stripe.Product> products, Models.Product product)
        {
            if (!products.Any(x => x.Name.Equals(product.Name, StringComparison.InvariantCultureIgnoreCase)))
            {
                var newProduct = await productService.CreateAsync(new ProductCreateOptions
                {
                    Name = product.Name,
                    StatementDescriptor = product.StatementDescription,
                    Metadata = product.Metadata,
                    Type = "service"
                });

                product.Id = newProduct.Id;
            }
        }

        /// <summary>
        /// Adds specified plan to stripe if it doesn't exist
        /// </summary>
        private async Task AddPlan(PlanService planService, StripeList<Stripe.Plan> plans, Models.Plan plan, string productId)
        {
            if (!plans.Any(x => x.Nickname.Equals(plan.Name)))
            {
                await planService.CreateAsync(new PlanCreateOptions
                {
                    Nickname = plan.Name,
                    Amount = plan.PricePerUnit,
                    Metadata = plan.Metadata,
                    Product = new PlanProductCreateOptions
                    {
                        Id = productId
                    },
                    Interval = plan.Interval.ToString().ToLower(),
                    Currency = plan.PlanCurrency.ToString().ToLower(),
                });
            }
        }
    }
}
