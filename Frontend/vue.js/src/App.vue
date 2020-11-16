<template>
  <v-app>
  <v-navigation-drawer app>
    <NavigationDrawer />
  </v-navigation-drawer>

  <v-app-bar app>
    Advertisiment Company
  </v-app-bar>

  <v-main>

    <v-container fluid>
      <router-view></router-view>
    </v-container>
  </v-main>

  <v-footer app>
    
  </v-footer>
</v-app>
</template>

<script>
import NavigationDrawer from "./components/NavigationDrawer";

export default {
  name: 'App',

  data: () => ({
    //
  }),

  components: {
    NavigationDrawer
  }
};
</script>
