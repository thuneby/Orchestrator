terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
    }
    azurecaf = {
      source  = "aztfmod/azurecaf"
    }
  }
  
  backend "azurerm" {
    resource_group_name  = "rg-terraform"
    storage_account_name = "orchestratorterraform"
    container_name       = "tfstate"
    key                  = "tfstate"
  }
}
provider "azurerm" {
  features {}
}
