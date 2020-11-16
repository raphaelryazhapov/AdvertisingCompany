<template>
    <v-card
        class="mx-auto">
        <v-list>
            <v-subheader>Companies</v-subheader>
            <v-list-item-group>
                <v-list-item
                    v-for="company in sortedCompanies"
                    :key="company.Id">

                    <v-list-item-icon>
                        <v-icon v-if="company.PartnerType.Name === 'VIP'">fas fa-angle-double-up</v-icon>
                        <v-icon v-if="company.PartnerType.Name === 'Affluent'">fas fa-angle-up</v-icon>
                    </v-list-item-icon>

                    <v-list-item-title>
                        {{ company.Name }}
                    </v-list-item-title>
                    
                    <v-list-item-action>
                        <v-btn>
                            Edit
                        </v-btn>
                    </v-list-item-action>
                    <v-list-item-action>
                        <v-btn
                            @click="deleteCompany(company)">
                            Delete
                        </v-btn>
                    </v-list-item-action>
                </v-list-item>
            </v-list-item-group>
        </v-list>
    </v-card>
</template>

<script>
export default {
    name: "Companies",
    data: () => ({
        companies: []
    }),
    computed: {
        sortedCompanies() {
            function compare(firstCompany, secondCompany) {
                let partnerTypePriority = [
                    "VIP",
                    "Affluent",
                    "Mass"
                ];

                let firstCompanyPriority = partnerTypePriority
                    .indexOf(firstCompany.PartnerType.Name);
                let secondCompanyPriority = partnerTypePriority
                    .indexOf(secondCompany.PartnerType.Name);

                if (firstCompanyPriority < secondCompanyPriority)
                    return -1;
                if (firstCompanyPriority > secondCompanyPriority)
                    return 1;
                return 0;
            }

            return [...this.companies].sort(compare);
        }
    },
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
        }
    }
}
</script>