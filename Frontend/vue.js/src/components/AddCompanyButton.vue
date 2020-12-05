<template>
    <v-dialog
      v-model="dialog"
      width="500"
    >
      <template v-slot:activator="{ on, attrs }">
        <v-btn
          color="red lighten-2"
          dark
          v-bind="attrs"
          v-on="on"
        >
          Add company
        </v-btn>
      </template>

      <v-card>
        <v-card-title class="headline grey lighten-2">
          Company adding dialog
        </v-card-title>
        <v-form v-model="valid">
            <v-container>
                <v-row>
                    <v-text-field
                        v-model="name"
                        label="Name"
                        required>
                    </v-text-field>
                    <v-text-field
                        v-model="ownerId"
                        label="OwnerId"
                        required>
                    </v-text-field>
                    <v-text-field
                        v-model="partnerTypeId"
                        label="PartnerTypeId"
                        :rules="partnerTypeRules"
                        required>
                    </v-text-field>
                </v-row>
            </v-container>
        </v-form>

        <v-divider></v-divider>

        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
            color="primary"
            text
            @click="addCompany"
            :disabled="!valid"
          >
            Add
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
</template>

<script>
export default {
    name: "AddCompanyButton",
    data: () => ({
        name: "",
        ownerId: null,
        partnerTypeId: null,
        valid: false,
        dialog: false,
        partnerTypeRules: [
          v => Boolean(v) || "type is required"
        ]
    }),
    methods: {
        addCompany() {
            this.dialog = false;
            
            let company = {
                Name: this.name,
                OwnerId: this.ownerId,
                PartnerTypeId: this.partnerTypeId
            }
            this.axios({
                method: "POST",
                url: "https://localhost:44371/api/partnercompany",
                headers: {
                    "Content-Type": "application/json"
                },
                data: JSON.stringify(company)
            })
            .then(() => {
                this.$emit("addCompany");
            });
        }
    }
}
</script>