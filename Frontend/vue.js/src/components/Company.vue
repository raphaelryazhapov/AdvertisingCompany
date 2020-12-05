<template>
    <v-container>
        <v-card>
            <v-card-title>
                {{ company.Name }}
            </v-card-title>

            <v-card-text>
                <h4
                    v-for="field in activeCompanyFields"
                    :key="field.name">
                    {{ field.name }} - {{ field.value }}
                </h4>
            </v-card-text>

            <v-card-actions>
                <v-btn
                    @click="deleteCompany">
                    Delete
                </v-btn>
                <v-btn
                    @click="showUserEditDialog = true">
                    Edit
                </v-btn>
            </v-card-actions>

            <v-dialog
                v-model="showUserEditDialog"
                persistent
                max-width="600px">
                <v-card>
                    <v-text-field
                        v-for="field in companyFields"
                        :key="field.name"
                        v-model="field.value"
                        :label="field.name"
                        :value="field.value">
                    </v-text-field>

                    <v-card-actions>
                        <v-btn
                            @click="updateCompany">
                            Apply
                        </v-btn>
                        <v-btn
                            @click="showUserEditDialog = false">
                            Close
                        </v-btn>
                    </v-card-actions>
                </v-card>
            </v-dialog>
        </v-card>
    </v-container>
</template>

<script>
export default {
    name: "Company",
    computed: {
        companyFields() {
            return [
                {
                    name: "Id",
                    value: this.company.Id,
                    active: this.headers.includes("Id")
                },
                {
                    name: "Name",
                    value: this.company.Name,
                    active: this.headers.includes("Name")
                },
                {
                    name: "OwnerId",
                    value: this.company.OwnerId,
                    active: this.headers.includes("OwnerId")
                },
                {
                    name: "PartnerTypeId",
                    value: this.company.PartnerTypeId,
                    active: this.headers.includes("PartnerTypeId")
                },
                {
                    name: "AdBlockCount",
                    value: this.company.AdBlockCount,
                    active: this.headers.includes("AdBlockCount")
                },
                {
                    name: "Owner",
                    value: this.company.Owner ? this.company.Owner.Name : "",
                    active: this.headers.includes("Owner")
                },
                {
                    name: "PartnerType",
                    value: this.company.PartnerType ? this.company.PartnerType.Name : "",
                    active: this.headers.includes("PartnerType")
                }
            ];
        },
        activeCompanyFields() {
            return this.companyFields.filter(field => field.active);
        } 
    },
    data: () => ({
        showUserEditDialog: false
    }),
    methods: {
        deleteCompany() {
            this.$emit("deleteCompany", this.company);
        },

        updateCompany() {
            this.showUserEditDialog = false;
            let newCompany = {
            };
            this.companyFields.forEach(field => {
                newCompany[field.name] = field.value;
            })

            this.$emit("updateCompany", newCompany);
        }
    },
    props: {
        company: Object,
        headers: Array
    }
}
</script>