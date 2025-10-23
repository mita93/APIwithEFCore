using WebAPIApp.Models;

namespace WebAPIApp.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Maintenances.Any())
                return; // すでにデータがある場合はスキップ

            var maint = new Maintenance
            {
                Number = 101,
                Description = "Main maintenance task",
                Settings = new List<Setting>
                {
                    new Setting
                    {
                        Name = "Temperature",
                        Description = "Temperature settings",
                        Items = new List<SettingItem>
                        {
                            new SettingItem
                            {
                                Name = "Heater",
                                Description = "Heater control",
                                ItemData = 25,
                                DataVariants = new List<DataVariant>
                                {
                                    new DataVariant { Value = 20, Description = "Low" },
                                    new DataVariant { Value = 25, Description = "Normal" },
                                    new DataVariant { Value = 30, Description = "High" }
                                }
                            }
                        }
                    }
                }
            };
            context.Maintenances.Add(maint);

            maint = new Maintenance
            {
                Number = 102,
                Description = "Uxxxx Initialize data",
                Settings = new List<Setting>
                {
                    new Setting
                    {
                        Name = "HeadCleaning",
                        Description = "Conduct cleaning head",
                        Items = new List<SettingItem>
                        {
                            new SettingItem
                            {
                                Name = "Heater",
                                Description = "Heater control",
                                ItemData = 25,
                                DataVariants = new List<DataVariant>
                                {
                                    new DataVariant { Value = 20, Description = "Low" },
                                    new DataVariant { Value = 25, Description = "Normal" },
                                    new DataVariant { Value = 30, Description = "High" }
                                }
                            },
                            new SettingItem
                            {
                                Name = "NozzleCheck",
                                Description = "Nozzle check control",
                                ItemData = 1
                            },
                            new SettingItem
                            {
                                Name = "HeadAlign",
                                Description = "Head align control",
                                ItemData = 1,
                                DataVariants = new List<DataVariant>
                                {
                                    new DataVariant { Value = 0, Description = "Standard" },
                                    new DataVariant { Value = 1, Description = "Advanced" },
                                    new DataVariant { Value = 2, Description = "Strong" }
                                }
                            }
                        }
                    },
                    new Setting
                    {
                        Name = "InkCharge",
                        Description = "Ink charge settings",
                        Items = new List<SettingItem>
                        {
                            new SettingItem
                            {
                                Name = "ChargeLevel",
                                Description = "Ink charge level",
                                ItemData = 3,
                                DataVariants = new List<DataVariant>
                                {
                                    new DataVariant { Value = 1, Description = "Low" },
                                    new DataVariant { Value = 2, Description = "Medium" },
                                    new DataVariant { Value = 3, Description = "High" }
                                }
                            }
                        }
                    }
                }
            };
            context.Maintenances.Add(maint);

            context.SaveChanges();
        }
    }
}
