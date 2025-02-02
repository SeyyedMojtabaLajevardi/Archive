﻿using Archive.BusinessLogic;
using Archive.DataAccess;
using Autofac;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace Archive
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // تنظیمات Dependency Injection با Autofac
            // تنظیمات کانتینر DI با Autofac
            var container = ConfigureServices();

            // ایجاد محدوده عمر و اجرای اپلیکیشن
            using (var scope = container.BeginLifetimeScope())
            {
                var mainForm = scope.Resolve<FormCreateDocument_Copy>();
                Application.Run(mainForm);
            }

            ////Application.EnableVisualStyles();
            ////Application.SetCompatibleTextRenderingDefault(false);
            ////Application.Run(new FormCreateDocument());
        }


        private static IContainer ConfigureServices()
        {
            var builder = new ContainerBuilder();

            // ثبت DbContext
            builder.RegisterType<ArchiveEntities>().AsSelf().InstancePerLifetimeScope();

            // ثبت سرویس‌ها و اینترفیس‌ها
            builder.RegisterType<DocumentService>().As<IDocumentService>();
            builder.RegisterType<ContentService>().As<IContentService>();
            builder.RegisterType<FileService>().As<IFileService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();

            // ثبت فرم‌ها
            builder.RegisterType<FormCreateDocument_Copy>();

            return builder.Build();
        }
    }

}