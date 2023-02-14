terraform {
    required_providers {
        azurerm = {
            source  = "hashicorp/azurerm"
        }
        azurecaf = {
      source  = "aztfmod/azurecaf"
      version = "~> 1.2.5"
        }
    }
  
    backend "azurerm" {
        resource_group_name  = "Terraform-state"
        storage_account_name = "orchestratorterraform"
        container_name       = "tfstate"
        key                  = "tfstate"
        }
}
provider "azurerm" {
  features {}
}