<template>
  <section class="profile text-center" v-if="profile">
    <ProfileCard :profile="profile" />
    <div class="p-3">
      <h1>Vaults</h1>
    </div>
    <section class="container-fluid">
      <div class="row">
        <div class="col-6 col-md-3 p-3" v-for="v in vaults">
          <VaultCard :key="v.id" :vault="v" />
        </div>
      </div>
    </section>
    <section class="vaults gap-3">
    </section>
    <div class="p-3">
      <h1>Keeps</h1>
    </div>
    <section class="keeps p-3">
      <KeepCard v-for="k in keeps" :key="k.id" :keep="k" />
    </section>
  </section>
  <div class="d-flex flex-column h-80 pos-relative" v-else>
    <span class="fadeIn m-auto fs-1 fw-700">Could not find this profile!</span>
    <Spinner />
  </div>
</template>

<script>
import { computed } from "@vue/reactivity";
import { onMounted } from "vue";
import { useRoute } from "vue-router";
import { AppState } from "../AppState";
import ProfileCard from "../components/ProfileCard.vue";
import { accountService } from "../services/AccountService";
import Pop from "../utils/Pop";

export default {
  setup() {
    const route = useRoute();
    async function setActiveProfile() {
      try {
        await accountService.getProfile(route.params.profileId);
      }
      catch (error) {
        Pop.error(error.message, "[setActiveProfile]");
      }
    }
    async function getUserVaults() {
      try {
        await accountService.getUserVaults(route.params.profileId);
      }
      catch (error) {
        Pop.error(error.message, "[getUserVaults]");
      }
    }
    async function getUserKeeps() {
      try {
        await accountService.getUserKeeps(route.params.profileId);
      }
      catch (error) {
        Pop.error(error.message, "[getUserKeeps]");
      }
    }
    onMounted(() => {
      setActiveProfile();
      getUserVaults();
      getUserKeeps();
    });
    return {
      route,
      profile: computed(() => AppState.activeProfile),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults)
    };
  },
  components: { ProfileCard }
}
</script>

<style scoped lang="scss">
.keeps {
  columns: 2;
}

@media screen and (min-width: 768px) {
  .keeps {
    columns: 4;
  }
}
</style>