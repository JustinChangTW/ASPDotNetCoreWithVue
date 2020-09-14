
// 定義component與路徑對應
export const componentMap = [
  { name: 'layout/Layout', component: import('@/layout') },
  { name: 'views/permission/page', component: import('@/views/permission/page') },
  { name: 'views/permission/directive', component: import('@/views/permission/directive') },
  { name: 'views/permission/role', component: import('@/views/permission/page') },
  { name: 'views/icons/index', component: import('@/views/icons/index') }
]

export default componentMap
