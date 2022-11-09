<template>
  <nav
    class="navbar navbar-expand-lg bg-nav px-3 p-md-3 justify-content-between align-items-center">
    <div class="nav-wrapper d-flex justify-content-between align-items-center">
      <div class="d-flex justify-content-between align-items-center gap-5 order-3 order-md-0">
        <div class="sm-hidden z-1">
          <router-link :to="{ name: 'Home' }">
            <button class="btn">Home</button>
          </router-link>
        </div>
        <div class="order-2 order-md-1">
          <CreateDropMenu v-if="user.isAuthenticated" />
        </div>
      </div>
      <div class="order-3 z-1">
        <Login />
      </div>
      <div class="logo-wrapper d-flex align-items-center justify-content-center order-0 order-md-2">
        <router-link :to="{ name: 'Home' }" class="unselectable">
          <img alt="logo" src="../assets/img/Keepr-logo.png" height="75.53" />
        </router-link>
      </div>
    </div>
  </nav>
</template>

<script>
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState";
import CreateDropMenu from "./CreateDropMenu.vue";
import Login from './Login.vue'
export default {
  setup() {
    return {
      user: computed(() => AppState.user)
    }
  },
  components: { Login, CreateDropMenu }
}
</script>

<style scoped>
.bg-nav {
  background-color: #FEF6F0;
}



.nav-wrapper {
  height: 100%;
  width: 100%;
}

@media screen and (min-width: 768px) {
  .logo-wrapper {
    position: absolute;
    height: 100%;
    width: 100%;
    left: 0;
    top: 0;
  }

  .nav-wrapper {
    position: relative;
    height: 100%;
    width: 100%;
  }

  .unselectable {
    pointer-events: none;
    cursor: default;
  }
}
</style>
