﻿using Archive.BusinessLogic;
using Archive.BusinessLogic.Implementation;
//using Archive.BusinessLogic.Interfaces;
using Archive.DataAccess;
using Autofac;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls.UI.Localization;

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
            // کد زیر برای تنظیمات گریدویو و نمایش متنهای  فارسی داخل آن است
            RadGridLocalizationProvider.CurrentProvider = new CustomGridLocalizationProvider();
            var container = ConfigureServices();

            // ایجاد محدوده عمر و اجرای اپلیکیشن
            //using (var scope = container.BeginLifetimeScope())
            //{
            //    var mainForm = new FormCreateDocument(1); // مقدار دلخواه برای mainCategoryId
            //    Application.Run(mainForm);
            //}

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormCreateDocument(new ArchiveFacadeService()));

            using (var scope = container.BeginLifetimeScope())
            {
                var archiveFacadeService = scope.Resolve<IArchiveFacadeService>();
                Application.Run(new FormMain(archiveFacadeService));
            }
            //using (var scope = container.BeginLifetimeScope())
            //{
            //    var mainForm = scope.Resolve<FormMain>();
            //    //var mainForm = scope.Resolve<FormCreateDocument_Speech>();
            //    //var mainForm = scope.Resolve<FormCreateDocument_Book>();
            //    Application.Run(mainForm);
            //}
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
            builder.RegisterType<FileTypeService>().As<IFileTypeService>();
            builder.RegisterType<ContentTypeService>().As<IContentTypeService>();

            // Register ArchiveFacadeService
            builder.RegisterType<ArchiveFacadeService>().As<IArchiveFacadeService>();

            builder.RegisterType<DocumentSubjectRelationService>().As<IDocumentSubjectRelationService>();

            // ثبت فرم‌ها
            builder.RegisterType<FormCreateDocument_Speech>();
            builder.RegisterType<FormCreateDocument_Book>();
            builder.RegisterType<FormFileType>();
            builder.RegisterType<FormSubject>();

            return builder.Build();
        }
    }

}