<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="AnimalsClassification.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Animals Classification</title>
    <link rel="stylesheet" href="StyleSheet1.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class ="Parameters">
            <h1>Animals Classification</h1>
            <p>
            <asp:Label ID="Label1" runat="server" Text="Choose classification:"></asp:Label>
            <asp:DropDownList ID="ClassificationOptions" runat="server">
                <asp:ListItem Text="Multiclass Decision Forest" Value="0"></asp:ListItem>
                <asp:ListItem Text="Multiclass Decision Jungle" Value="1"></asp:ListItem>
                <asp:ListItem Text="Multiclass Logistic Regression" Value="2"></asp:ListItem>
                <asp:ListItem Text="Multiclass Neural Network" Value="3"></asp:ListItem>
            </asp:DropDownList>
            </p>
            <p>
            <asp:Label ID="LabelName" runat="server" Text="Animal Name:"></asp:Label>
            <asp:TextBox ID="AnimalNameTextBox" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="HairLabel" runat="server" Text="Hair?:"></asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server">
                <asp:ListItem Text="True" Value="1"></asp:ListItem>
                <asp:ListItem Text="False" Value="0"></asp:ListItem>
            </asp:DropDownList>          
        </p>
        <p>
            <asp:Label ID="FeathersLabel" runat="server" Text="Feathers?:"></asp:Label>
            <asp:DropDownList ID="FeathersDownList" runat="server">
                <asp:ListItem Text="True" Value="1"></asp:ListItem>
                <asp:ListItem Text="False" Value="0"></asp:ListItem>
            </asp:DropDownList>          
        </p>
        <p>
            <asp:Label ID="EggsLabel" runat="server" Text="Eggs?:"></asp:Label>
            <asp:DropDownList ID="EggsDropDownList" runat="server">
                <asp:ListItem Text="True" Value="1"></asp:ListItem>
                <asp:ListItem Text="False" Value="0"></asp:ListItem>
            </asp:DropDownList>          
        </p>
        <p>
            <asp:Label ID="MilkLabel" runat="server" Text="Milk?:"></asp:Label>
            <asp:DropDownList ID="MilkDropDownList" runat="server">
                <asp:ListItem Text="True" Value="1"></asp:ListItem>
                <asp:ListItem Text="False" Value="0"></asp:ListItem>
            </asp:DropDownList>          
        </p>
        <p>
            <asp:Label ID="AirborneLabel" runat="server" Text="Airborne?:"></asp:Label>
            <asp:DropDownList ID="AirborneDropDownList" runat="server">
                <asp:ListItem Text="True" Value="1"></asp:ListItem>
                <asp:ListItem Text="False" Value="0"></asp:ListItem>
            </asp:DropDownList>          
        </p>
        <p>
            <asp:Label ID="AquaticLabel" runat="server" Text="Aquatic?:"></asp:Label>
            <asp:DropDownList ID="AquaticDropDownList" runat="server">
                <asp:ListItem Text="True" Value="1"></asp:ListItem>
                <asp:ListItem Text="False" Value="0"></asp:ListItem>
            </asp:DropDownList>          
        </p>
        <p>
            <asp:Label ID="PredatorLabel" runat="server" Text="Predator?:"></asp:Label>
            <asp:DropDownList ID="PredatorDropDownList" runat="server">
                <asp:ListItem Text="True" Value="1"></asp:ListItem>
                <asp:ListItem Text="False" Value="0"></asp:ListItem>
            </asp:DropDownList>          
        </p>
        <p>
            <asp:Label ID="ToothedLabel" runat="server" Text="Toothed?:"></asp:Label>
            <asp:DropDownList ID="ToothedDropDownList" runat="server">
                <asp:ListItem Text="True" Value="1"></asp:ListItem>
                <asp:ListItem Text="False" Value="0"></asp:ListItem>
            </asp:DropDownList>          
        </p>
        <p>
            <asp:Label ID="BackboneLabel" runat="server" Text="Backbone?:"></asp:Label>
            <asp:DropDownList ID="BackboneDropDownList" runat="server">
                <asp:ListItem Text="True" Value="1"></asp:ListItem>
                <asp:ListItem Text="False" Value="0"></asp:ListItem>
            </asp:DropDownList>          
        </p>
         <p>
            <asp:Label ID="BreathesLabel" runat="server" Text="Breathes?:"></asp:Label>
            <asp:DropDownList ID="BreathesDropDownList" runat="server">
                <asp:ListItem Text="True" Value="1"></asp:ListItem>
                <asp:ListItem Text="False" Value="0"></asp:ListItem>
            </asp:DropDownList>          
        </p>
         <p>
            <asp:Label ID="VenomouesLabel" runat="server" Text="Venomous?:"></asp:Label>
            <asp:DropDownList ID="VenomousDropDownList" runat="server">
                <asp:ListItem Text="True" Value="1"></asp:ListItem>
                <asp:ListItem Text="False" Value="0"></asp:ListItem>
            </asp:DropDownList> 
        </p>
        <p>
            <asp:Label ID="FinsLabel" runat="server" Text="Fins?:"></asp:Label>
            <asp:DropDownList ID="FinsDropDownList" runat="server">
                <asp:ListItem Text="True" Value="1"></asp:ListItem>
                <asp:ListItem Text="False" Value="0"></asp:ListItem>
            </asp:DropDownList> 
        </p>
        <p>
            <asp:Label ID="LegsLabel" runat="server" Text="Legs?:"></asp:Label>
            <asp:TextBox ID="LegsTextbox" runat="server"></asp:TextBox>
          
        </p>
        <p>
            <asp:Label ID="TailLabel" runat="server" Text="Tail?:"></asp:Label>
            <asp:DropDownList ID="TailDropDownList" runat="server">
                <asp:ListItem Text="True" Value="1"></asp:ListItem>
                <asp:ListItem Text="False" Value="0"></asp:ListItem>
            </asp:DropDownList> 
        </p>
        <p>
            <asp:Label ID="DomesticLabel" runat="server" Text="Domestic?:"></asp:Label>
            <asp:DropDownList ID="DomesticDropDownList" runat="server">
                <asp:ListItem Text="True" Value="1"></asp:ListItem>
                <asp:ListItem Text="False" Value="0"></asp:ListItem>
            </asp:DropDownList> 
        </p>
        <p>
            <asp:Label ID="CatsizeLabel" runat="server" Text="Catsize?:"></asp:Label>
            <asp:DropDownList ID="CatsizeDropDownList" runat="server">
                <asp:ListItem Text="True" Value="1"></asp:ListItem>
                <asp:ListItem Text="False" Value="0"></asp:ListItem>
            </asp:DropDownList> 
        </p>
        <p>
            <asp:Button ID="PredictButton" runat="server" Text="Predict" OnClick="PredictButton_Click" ></asp:Button>
        </p>
        <p>
            
            <asp:Label ID="ResultValue" runat="server" Text=""></asp:Label>
        </p>
          
        </div>
        
    </form>
</body>
</html>

