using Backend.Service.Payment.Interfaces;
using Backend.Service.Payment.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Stripe;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Backend.Service.Payment.Configuration
{
    public class StripeConfiguration
    {
        /// <summary>
        /// Stripe configuration: If no products or plans are set up on Stripe or if any is missing.
        /// This will always bring back the specified configuration
        /// This method is called once in Startup.Configuration on beggining of apps runtime
        /// </summary>
        public static async Task ConfigureProducts(StripeSettings settings = null)
        {
            if(settings != null)
            {
                // calling from program.cs
                Stripe.StripeConfiguration.ApiKey = settings.SecretKey;
            }

            var productService = new ProductService();

            var products = await productService.ListAsync();

            var planService = new PlanService();
            var plans = await planService.ListAsync();

            foreach (var product in GetProducts().Products)
            {
                await AddProduct(productService, products, product);

                var productId = product.Id ?? products.First(x =>
                                    x.Name.Equals(product.Name, StringComparison.InvariantCultureIgnoreCase)).Id;

                foreach (var plan in product.Plans)
                {
                    await AddPlan(planService, plans, plan, productId);
                }
            }
        }

        /// <summary>
        /// Adds paying customer to stripe
        /// Returns UID customer ID which is associated with app user
        /// </summary>
        /// <returns></returns>
        public static async Task<string> AddCustomer(string fullName, string email)
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
        public static ProductsViewModel GetProducts()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                       + "/Configuration/Products.json";

            var data = System.IO.File.ReadAllText(path);
            return JsonConvert.DeserializeObject<ProductsViewModel>(data);
        }

        /// <summary>
        /// Adds specified product to stripe if it doesn't exist
        /// </summary>
        private static async Task AddProduct(ProductService productService, StripeList<Stripe.Product> products, Models.Product product)
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
        private static async Task AddPlan(PlanService planService, StripeList<Stripe.Plan> plans, Models.Plan plan, string productId)
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
