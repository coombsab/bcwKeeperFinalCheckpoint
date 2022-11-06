<template>
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
   <Tag :tag="'Hello World'" />
  </div>
</template>

<script>
import Tag from "../components/Tag.vue";

export default {
    setup() {
        return {};
    },
    components: { Tag }
}
</script>

<style scoped lang="scss">

</style>
