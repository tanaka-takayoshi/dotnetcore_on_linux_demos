﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HelloReact.Models;

namespace HelloReact.Migrations
{
    [DbContext(typeof(ToDoContext))]
    [Migration("20160927064504_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("HelloReact.Models.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Complete");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 512);

                    b.HasKey("Id");

                    b.ToTable("ToDo");
                });
        }
    }
}
