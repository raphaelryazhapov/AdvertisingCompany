<template>
    <v-list
        dense
        nav
      >
        <v-list-item
          v-for="item in links"
          :key="item.name"
          link :to="item.to">

          <v-list-item-content>
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
</template>

<script>
export default {
    name: "NavigationDrawer",
    data: () => ({
        links: [
            {
                title: "Companies",
                to: "/Companies"
            }
        ]
    })
}
</script>