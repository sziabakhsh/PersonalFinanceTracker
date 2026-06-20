import { Table, Button, Card} from "react-bootstrap";

import { useCategories} from "../hooks/useCategories";

import { useDeleteCategory } from "../hooks/useDeleteCategory"; 

export function CategoryGrid({
 search,
 onEdit
}: any) {

 const {
  data=[]
 } =
 useCategories();

 const del =
 useDeleteCategory();

 const rows =
 data.filter(x =>
 x.name
 .toLowerCase()
 .includes(
 search
 .toLowerCase()
 ));

 return (

<Card>

<Card.Body>

<Table hover>

<thead>

<tr>

<th>Name</th>

<th width="180">

Actions

</th>

</tr>

</thead>

<tbody>

{
rows.map(
item=>(

<tr
key={item.id}
>

<td>

{item.name}

</td>

<td>

<Button
size="sm"
className="me-2"
onClick={()=>
onEdit(item)
}
>

Edit

</Button>

<Button
size="sm"
variant="danger"
onClick={()=>
del.mutate(
item.id
)
}
>

Delete

</Button>

</td>

</tr>

))

}

</tbody>

</Table>

</Card.Body>

</Card>

);
}