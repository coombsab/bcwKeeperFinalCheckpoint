<template>
  <section class="profile">
    <Tag :tag="'Profile Page ' + route.params.profileId" />
  </section>
</template>

<script>
import { useRoute } from "vue-router";

export default {
  setup() {
    const route = useRoute()
    return {
      route
    }
  }
}
</script>

<style scoped lang="scss">
  
</style>