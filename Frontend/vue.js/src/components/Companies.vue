<template>
    <v-container
        v-if="Boolean(companies)">
        <AddCompanyButton
            @addCompany = addCompany />
        <v-row>
            <v-checkbox
                v-model="headers"
                v-for="(value, prop) in companies[0]"
                :key="prop"
                :label="prop"
                :value="prop">
            </v-checkbox>
        </v-row>
        <Company
            v-for="company in companies"
            :key="company.Name"
            :company = company
            :headers = headers 
            @deleteCompany = deleteCompany
            @updateCompany = updateCompany />
    </v-container>
</template>

<script>
import Company from "./Company";
import AddCompanyButton from "./AddCompanyButton";

export default {
    name: "Companies",
    components: {
        Company,
        AddCompanyButton
    },
    data: () => ({
        companies: [],
        headers: []
    }),
    created: function() {
        this.loadCompanies();
    },
    methods: {
        loadCompanies() {
            this.axios({
                method: "GET",
                url: "https://localhost:44371/api/partnercompany"
            })
            .then(reponse => {
                this.companies = reponse.data;
            });
        },

        deleteCompany(company) {
            this.axios({
                method: "DELETE",
                url: "https://localhost:44371/api/partnercompany/" + company.Id
            })
            .then(() => {
                this.companies = this.companies.filter(item => item.Id !== company.Id);
            });
        },
        
        addCompany() {
            this.loadCompanies();
        },

        updateCompany(company) {
            let companyToSend = {
                Id: company.Id,
                Name: company.Name,
                PartnerTypeId: company.PartnerTypeId,
                OwnerId: company.OwnerId,
                AdBlockCount: company.AdBlockCount
            };

            this.axios({
                method: "PUT",
                url: "https://localhost:44371/api/partnercompany",
                headers: {
                    "Content-Type": "application/json"
                },
                data: JSON.stringify(companyToSend)
            })
            .then(() => {
                this.loadCompanies();
            });
        }
    }
}
</script>