<template>
  <a-modal
    :title="title"
    width="40%"
    :visible="visible"
    :confirmLoading="loading"
    @ok="handleSubmit"
    @cancel="()=>{this.visible=false}"
  >
    <a-spin :spinning="loading">
      <a-form-model ref="form" :model="entity" :rules="rules" v-bind="layout">
        <a-form-model-item label="书名" prop="Name">
          <a-input v-model="entity.Name" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="作者" prop="Author">
          <a-input v-model="entity.Author" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="描述" prop="Desc">
          <a-input v-model="entity.Desc" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="一级分类" prop="CategoryId">
          <a-input v-model="entity.CategoryId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="二级分类" prop="SubCategoryId">
          <a-input v-model="entity.SubCategoryId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="评分" prop="Rate">
          <a-input v-model="entity.Rate" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="封面" prop="Cover">
          <a-input v-model="entity.Cover" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="状态
0未知
1连载
2完本
3暂停" prop="Status">
          <a-input v-model="entity.Status" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="字数" prop="WordNums">
          <a-input v-model="entity.WordNums" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="AddTime" prop="AddTime">
          <a-input v-model="entity.AddTime" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="是否已经提取章节" prop="Process">
          <a-input v-model="entity.Process" autocomplete="off" />
        </a-form-model-item>
      </a-form-model>
    </a-spin>
  </a-modal>
</template>

<script>
export default {
  props: {
    parentObj: Object
  },
  data() {
    return {
      layout: {
        labelCol: { span: 5 },
        wrapperCol: { span: 18 }
      },
      visible: false,
      loading: false,
      entity: {},
      rules: {},
      title: ''
    }
  },
  methods: {
    init() {
      this.visible = true
      this.entity = {}
      this.$nextTick(() => {
        this.$refs['form'].clearValidate()
      })
    },
    openForm(id, title) {
      this.init()

      if (id) {
        this.loading = true
        this.$http.post('/EBook/Book/GetTheData', { id: id }).then(resJson => {
          this.loading = false

          this.entity = resJson.Data
        })
      }
    },
    handleSubmit() {
      this.$refs['form'].validate(valid => {
        if (!valid) {
          return
        }
        this.loading = true
        this.$http.post('/EBook/Book/SaveData', this.entity).then(resJson => {
          this.loading = false

          if (resJson.Success) {
            this.$message.success('操作成功!')
            this.visible = false

            this.parentObj.getDataList()
          } else {
            this.$message.error(resJson.Msg)
          }
        })
      })
    }
  }
}
</script>
