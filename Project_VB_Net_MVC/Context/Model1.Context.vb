﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure

Partial Public Class DBNetEntities3
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=DBNetEntities3")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Overridable Property cart() As DbSet(Of cart)
    Public Overridable Property cart_detail() As DbSet(Of cart_detail)
    Public Overridable Property cart_reminder() As DbSet(Of cart_reminder)
    Public Overridable Property category() As DbSet(Of category)
    Public Overridable Property custom_order() As DbSet(Of custom_order)
    Public Overridable Property custom_order_notification() As DbSet(Of custom_order_notification)
    Public Overridable Property delivery() As DbSet(Of delivery)
    Public Overridable Property favorite() As DbSet(Of favorite)
    Public Overridable Property ingredient() As DbSet(Of ingredient)
    Public Overridable Property ingredient_category() As DbSet(Of ingredient_category)
    Public Overridable Property notification() As DbSet(Of notification)
    Public Overridable Property order() As DbSet(Of order)
    Public Overridable Property order_detail() As DbSet(Of order_detail)
    Public Overridable Property post() As DbSet(Of post)
    Public Overridable Property post_comment() As DbSet(Of post_comment)
    Public Overridable Property product() As DbSet(Of product)
    Public Overridable Property purchased_order() As DbSet(Of purchased_order)
    Public Overridable Property purchased_order_detail() As DbSet(Of purchased_order_detail)
    Public Overridable Property purchased_product() As DbSet(Of purchased_product)
    Public Overridable Property rate() As DbSet(Of rate)
    Public Overridable Property storage() As DbSet(Of storage)
    Public Overridable Property user() As DbSet(Of user)
    Public Overridable Property user_info() As DbSet(Of user_info)

End Class