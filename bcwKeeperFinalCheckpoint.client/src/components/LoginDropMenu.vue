<template>
  <div class="drop-up">
    <div type="button" class=" drop-btn bg-dark border-0 no-select circle" @click="toggleShow()" aria-label="Open Login Menu">
      <div v-if="account.picture || user.picture">
        <img :src="account.picture || user.picture" alt="account photo" class="account-photo circle" />
      </div>
    </div>
    <div id="loginDropMenu" class="drop-up-content rounded elevation-5 p-1" aria-label="Login Menu">
      <router-link :to="{ name: 'Account' }">
        <div class="list-group-item dropdown-item list-group-item-action">
          Manage Account
        </div>
      </router-link>
      <div class="list-group-item dropdown-item list-group-item-action text-center text-danger selectable"
        @click="logout">
        <i class="mdi mdi-logout"></i>
        logout
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState";
import { AuthService } from "../services/AuthService";

export default {
  setup() {

    //REVIEW Look into these as a method to close popup by clicking outside element
    function hideOnClickOutside(element) {
      const outsideClickListener = event => {
        if (!element.contains(event.target) && isVisible(element)) { // or use: event.target.closest(selector) === null
          element.style.display = 'none';
          removeClickListener();
        }
      }

      const removeClickListener = () => {
        document.removeEventListener('click', outsideClickListener);
      }

      document.addEventListener('click', outsideClickListener);
    }

    const isVisible = elem => !!elem && !!(elem.offsetWidth || elem.offsetHeight || elem.getClientRects().length);
    // source (2018-03-11): https://github.com/jquery/jquery/blob/master/src/css/hiddenVisibleSelectors.js

    return {
      user: computed(() => AppState.user),
      account: computed(() => AppState.account),
      async logout() {
        AuthService.logout();
      },
      toggleShow() {
        document.getElementById("loginDropMenu").classList.toggle("show");
      }
    }
  }
}
</script>

<style scoped lang="scss">
.circle {
  border-radius: 50%;
}

.account-photo {
  height: 53.3px;
  width: 53.3px;
}

.drop-up {
  position: relative;
  display: inline-block;
}

.drop-up-content {
  display: none;
  position: absolute;
  width: fit-content;
  background-color: white;
  bottom: 50%;
  left: -175px;
  z-index: 1;
}

.show {
  display: block;
}

.drop-up-content a {
  color: black;
  padding: 12px 16px;
  text-decoration: none;
  display: block;
}

.drop-up-content a:hover {
  background-color: #ccc
}

.drop-up:hover .drop-btn {
  background-color: #2980B9;
}

@media screen and (min-width: 768px) {
  .account-photo {
    height: 64px;
    width: 64px;
  }

  .drop-up {
    position: relative;
    display: inline-block;
  }

  .drop-up-content {
    display: none;
    position: absolute;
    width: fit-content;
    bottom: -50%;
    left: -175px;
    z-index: 1;
    transition: 0.2 linear;
  }

  .drop-up:hover .drop-up-content {
    display: block;
  }

  .drop-up:hover .drop-btn {
    background-color: #2980B9;
  }
}
</style>